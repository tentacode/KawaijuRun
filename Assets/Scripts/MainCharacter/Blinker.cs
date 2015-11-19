using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour
{
    public float hiddenInterval;
    public float visibleInterval;

    private bool doBlink = false;
    private SpriteRenderer spriteRenderer;
    private float nextBlink = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	void Update ()
    {
        if (!doBlink) {
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,1.0f);
            return;
        }

        if (Time.time < nextBlink) {
            return;
        }

        var isVisible = spriteRenderer.color.a != 0.0f;
        if (isVisible) {
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,0.0f);
            nextBlink = Time.time + hiddenInterval;
        } else {
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,1.0f);
            nextBlink = Time.time + visibleInterval;
        }
	}

    public void SetBlink(bool newBlink)
    {
        doBlink = newBlink;
    }
}
