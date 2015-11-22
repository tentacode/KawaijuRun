using UnityEngine;
using System.Collections;

public class DestroyByTrigger : MonoBehaviour
{
    public GameObject destroyObject;

    void OnTriggerEnter2D(Collider2D other)
    {
		if (destroyObject.name == other.gameObject.name)
        {
            Destroy(gameObject);
        }
    }
}
