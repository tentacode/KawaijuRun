﻿using UnityEngine;
using System.Collections;

public class MainCharacterMover : MonoBehaviour
{
    public float walkSpeed = 10f;

    public float currentSpeed;
    private Rigidbody2D rb;

    private bool doMove = true;
    private float initialSpeed;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();

        initialSpeed = walkSpeed;
	}
	
	void Update ()
    {
        MainCharacterController.States state = GetComponent<MainCharacterController>().GetState();
        if (state == MainCharacterController.States.Dead || state == MainCharacterController.States.Start || state == MainCharacterController.States.GameOver) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            doMove = !doMove;
        }


        if(doMove)
        {
            Walk();
        }
        else
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        currentSpeed = rb.velocity.x;
    }

    public void ResetSpeed()
    {
        walkSpeed = initialSpeed;
    }

    void Walk()
    {
        rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }
}
