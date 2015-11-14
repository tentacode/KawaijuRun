using UnityEngine;
using System.Collections;

// class BackgroundScroller
// description : scrolls a gameObject, use to scroll a background and have a parallax

public class BackgroundScroller : MonoBehaviour
{
    public GameController gameController;

    public float scrollSpeedIdle = 1.0f;
    public float scrollSpeed = 1.0f;
    public Rigidbody2D mainCharacterRB;

    private float tileLenght = 0.0f;
    private Vector3 startPosition;
    private Vector2 mainCharacterBasePosition;
    
    void Start()
    {
        startPosition = transform.position;
        tileLenght = this.GetComponent<BoxCollider2D>().size.x * transform.lossyScale.x;
        mainCharacterBasePosition = mainCharacterRB.position;
    }

    void Update()
    {
        float newPosition;

        if (mainCharacterRB.velocity == Vector2.zero) {
            newPosition = Mathf.Repeat(Time.time * scrollSpeedIdle, tileLenght); // TODO
        } else {
            newPosition = Mathf.Repeat((mainCharacterRB.position.x - mainCharacterBasePosition.x) * scrollSpeed, tileLenght);
        }

        transform.position = startPosition + Vector3.left * newPosition + new Vector3(transform.parent.position.x, 0.0f, 0.0f);
    }
}
