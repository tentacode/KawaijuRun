using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

[Serializable]
public struct ScenarioStep
{
    public enum EnnemyActions { wait, shoot, move };

    public EnnemyActions action;
    public float delayForNextStep;
}

public class EnnemyController : MonoBehaviour
{
    public List<ScenarioStep> scenario;
    public GameObject shootPoint;
    public GameObject ammo;

    public float movingSpeed;
    public bool isKinematic;
    
    public enum EnnemyTypes {Tank, Helico};
    public EnnemyTypes ennemyType;

    private Rigidbody2D rb;
    private int stepIndex = 0;
    private bool isTriggered = false;
    [SerializeField]
    private bool isMoving = false;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        if(isMoving)
        {
            rb.velocity = new Vector2(-1f * movingSpeed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnerTrigger")
        {
            rb.isKinematic = isKinematic;
            BeginBehavior();
        }

        if (other.tag == "Player" || other.tag == "BulletMC")
        {
            if (other.tag == "BulletMC") {
                Destroy(other.gameObject);
            }
            Die();
        }
    }

    void BeginBehavior()
    {
        if (isTriggered) {
            return;
        }

        isTriggered = true;
        StartCoroutine(ExecuteStep());
    }

    IEnumerator ExecuteStep()
    {
        if (scenario.Count == 0) {
            return false;
        }

        ScenarioStep step = scenario[stepIndex];

        switch (step.action)
        {
            case ScenarioStep.EnnemyActions.move:
                Move();
                break;

            case ScenarioStep.EnnemyActions.shoot:
                Shoot();
                break;

            case ScenarioStep.EnnemyActions.wait:
                Stop();
                break;
        }

        yield return new WaitForSeconds(step.delayForNextStep);
        stepIndex++;
        if (stepIndex >= scenario.Count) {
            stepIndex = 0;
        }

        StartCoroutine(ExecuteStep());
    }

    public virtual void Shoot()
    {
        Instantiate(ammo, gameObject.transform.position, Quaternion.identity);
        ammo.GetComponent<Ammo>().Launch();
    }

    void Move()
    {
        isMoving = true;
    }

    void Stop()
    {
        isMoving = false;
    }

    void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
