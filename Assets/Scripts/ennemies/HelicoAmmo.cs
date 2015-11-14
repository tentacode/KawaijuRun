using UnityEngine;
using System.Collections;
using System;

public class HelicoAmmo : Ammo
{
    public float speed;
    public Vector2 launchVelocity;

    private bool isInEyeLine = false;
    private float timeLaunched;
    private GameObject eyePosition;

    public override void Launch()
    {
        eyePosition = GameObject.FindGameObjectsWithTag("KaijuEye")[0];
        timeLaunched = Time.time;
        fall();
    }

    void FixedUpdate()
    {
        if(!isInEyeLine && transform.position.y <= eyePosition.transform.position.y)
        {
            isInEyeLine = true;
            goForward();
        }
    }

    void fall ()
    {
        GetComponent<Rigidbody2D>().velocity = launchVelocity;
    }
    
    void goForward ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * speed, 0f);
    }
}
