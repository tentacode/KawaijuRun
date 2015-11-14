using UnityEngine;
using System.Collections;

// class BackgroundScroller
// description : scrolls a gameObject, use to scroll a background and have a parallax

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed = 1.0f;

    [SerializeField]
    private float tileLenght = 0.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        tileLenght = this.GetComponent<BoxCollider2D>().size.x * transform.lossyScale.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileLenght);
        transform.position = startPosition + Vector3.left * newPosition + new Vector3(transform.parent.position.x, 0.0f, 0.0f);
    }
}
