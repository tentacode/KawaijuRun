using UnityEngine;
using System.Collections;

public class MainCharacterMover : MonoBehaviour
{
    public float walkSpeed = 10f;

    private float currentSpeed { get; set; }
    private Rigidbody2D rb;

    private int health = 3;

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


        Walk();
        currentSpeed = rb.velocity.x;
	}

    void Walk()
    {
        rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
    }
}
