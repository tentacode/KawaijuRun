using UnityEngine;
using System.Collections;
using System;

public class HelicoAmmo : Ammo
{
    public float speed;
    public float prepareTime = 0.2f;
    public Vector2 launchVelocity;

    private bool isInEyeLine = false;
    private GameObject eyePosition;

    public override void Launch()
    {
        eyePosition = GameObject.FindGameObjectsWithTag("KaijuEye")[0];
        prepare();
    }

    void FixedUpdate()
    {
        if(!isInEyeLine && transform.position.y <= eyePosition.transform.position.y)
        {
            isInEyeLine = true;
            goForward();
        }
    }

    IEnumerator prepare ()
    {
        yield return new WaitForSeconds(prepareTime);
        fall();
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
