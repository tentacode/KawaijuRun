using UnityEngine;
using System.Collections;

public class EnnemyCollisionManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SpawnerTrigger") {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }

        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
}
