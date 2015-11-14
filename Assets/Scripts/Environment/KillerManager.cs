using UnityEngine;
using System.Collections;

public class KillerManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ennemy")
        {
            Destroy(other.gameObject, 0.5f);
        }
    }
}
