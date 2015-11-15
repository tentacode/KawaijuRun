using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour
{
    public Vector2 defaultPosition;

    private GameObject player; // reference to the player

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + defaultPosition.x,
                                         transform.position.y,
                                         transform.position.z);
    }
}
