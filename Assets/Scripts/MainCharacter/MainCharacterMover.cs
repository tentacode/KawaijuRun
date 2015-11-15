using UnityEngine;
using System.Collections;

public class MainCharacterMover : MonoBehaviour
{
    public float walkSpeed = 10f;

    public float currentSpeed;
    private Rigidbody2D rb;

    private int health = 3;
    private bool doMove = true;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        MainCharacterController.States state = GetComponent<MainCharacterController>().getState();
        if (state == MainCharacterController.States.Dead || state == MainCharacterController.States.Start) {
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

    void Walk()
    {
        rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }
}
