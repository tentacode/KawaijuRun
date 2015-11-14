using UnityEngine;
using System.Collections;
using System;

public class EnnemyController : MonoBehaviour
{
    public EnnemyScenario scenario;
    public GameObject shootPoint;
    public GameObject ammo;

    public float movingSpeed;

    private bool isMoving = false;
    private Rigidbody2D rb;
    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
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

    public void setState(ScenarioStep.EnnemyActions action)
    {
        Debug.Log("set action to " + action);
        switch (action)
        {
            case ScenarioStep.EnnemyActions.move:
                move();
                break;

            case ScenarioStep.EnnemyActions.shoot:
                shoot();
                break;

            case ScenarioStep.EnnemyActions.wait:
                stop();
                break;  
        }
    }

    void BeginBehavior()
    {
        scenario.beginScenario(setState);
    }

    void shoot()
    {
        Debug.Log("shoot");
        Instantiate(ammo, gameObject.transform.position, Quaternion.identity);
        ammo.GetComponent<Ammo>().Launch();
    }

    void move()
    {
        Debug.Log("move");
        rb.velocity = new Vector2(-1f * movingSpeed, 0f);
        isMoving = true;
    }

    void stop()
    {
        Debug.Log("stop");
        rb.velocity = new Vector2(0f, 0f);
        isMoving = false;
    }

    void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }


}
