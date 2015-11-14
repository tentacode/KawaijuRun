using UnityEngine;
using System.Collections;

public abstract class Ammo : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        Launch();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void Launch();

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
