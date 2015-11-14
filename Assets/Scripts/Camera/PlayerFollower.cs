using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player; // reference to the player
    public Vector2 defaultPosition;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + defaultPosition.x,
                                         transform.position.y,
                                         transform.position.z);
    }
}
