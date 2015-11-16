using UnityEngine;
using System.Collections;

// class BackgroundScroller
// description : scrolls a gameObject, use to scroll a background and have a parallax

public class BackgroundScroller : MonoBehaviour
{
    public GameController gameController;
    
    public float scrollSpeed = 1.0f;

    private float tileLenght = 0.0f;
    private Vector3 startPosition;
    private Vector2 mainCharacterBasePosition;
    private GameObject mainCharacter;
    private Rigidbody2D mainCharacterRB;

    void Start()
    {
        startPosition = transform.position;
        tileLenght = this.GetComponent<BoxCollider2D>().size.x * transform.lossyScale.x;
        mainCharacter = GameObject.FindGameObjectsWithTag("Player")[0];
        mainCharacterRB = mainCharacter.GetComponent<Rigidbody2D>();
        mainCharacterBasePosition = mainCharacterRB.position;
    }

    void Update()
    {
        float newPosition;

        if (mainCharacter.GetComponent<MainCharacterController>().GetState() == MainCharacterController.States.Start) {
            newPosition = Mathf.Repeat(Time.time * mainCharacter.GetComponent<MainCharacterMover>().walkSpeed * scrollSpeed, tileLenght); // TODO
        } else {
            newPosition = Mathf.Repeat((mainCharacter.transform.position.x - mainCharacterBasePosition.x) * scrollSpeed, tileLenght);
        }

        transform.position = Vector3.right * (transform.parent.position.x - newPosition) + startPosition;
    }

    public void setLaunchPosition()
    {
        startPosition = transform.position;
    }
}
