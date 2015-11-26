using UnityEngine;
using System.Collections;

public class BasicMover : MonoBehaviour
{
    public float speed;

    private bool hasPassTrigger = false;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hasPassTrigger)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnerTrigger")
        {
            hasPassTrigger = true;
        }
    }
}
