using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour
{
    public float amplitude;
    public float hoverSpeed;

    [SerializeField]
    private bool hasPassTrigger = false;
    private float triggerPassTime;
    private float initialHeight;

    void Start()
    {
        initialHeight = transform.position.y;
    }

	// Update is called once per frame
	void Update ()
    {
	    if(hasPassTrigger)
        {
            transform.position = new Vector2(transform.position.x,
                                             amplitude * Mathf.Sin((Time.time - triggerPassTime) * hoverSpeed) + initialHeight);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpawnerTrigger")
        {
            hasPassTrigger = true;
            triggerPassTime = Time.time;
        }
    }
}
