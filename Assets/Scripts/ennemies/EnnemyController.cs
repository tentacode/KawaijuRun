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

    private Rigidbody2D rb;
    private int stepIndex = 0;
    private bool isTriggered = false;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnerTrigger")
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            BeginBehavior();
        }

        if (other.tag == "Player")
        {
            Die();
        }
    }

    void BeginBehavior()
    {
        if (isTriggered) {
            return;
        }

        isTriggered = true;
        Debug.Log("Begin behavior");
        StartCoroutine(ExecuteStep());
    }

    IEnumerator ExecuteStep()
    {
        ScenarioStep step = scenario[stepIndex];

        Debug.Log("set action to " + step.action);
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

    void Shoot()
    {
        Debug.Log("shoot");
        Instantiate(ammo, gameObject.transform.position, Quaternion.identity);
        ammo.GetComponent<Ammo>().Launch();
    }

    void Move()
    {
        Debug.Log("move");
        rb.velocity = new Vector2(-1f * movingSpeed, 0f);
    }

    void Stop()
    {
        Debug.Log("stop");
        rb.velocity = new Vector2(0f, 0f);
    }

    void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
