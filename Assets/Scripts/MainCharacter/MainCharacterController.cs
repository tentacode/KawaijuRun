using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting, Jumping};
    public float invulerabilityDelay;

    private States state = States.Idle;
    private int heart = 3;
    private bool invulnerable = false;

    public void SetState(States newState)
    {
        state = newState;
    }

    public States getState()
    {
        return state;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (invulnerable) {
            return;
        }

        if (other.tag == "Ennemy")
        {
            StartCoroutine(Hurt());
        }
    }

    IEnumerator Hurt()
    {
        heart--;
        Debug.Log("Heart:" + heart);

        GameObject heartUi = GameObject.FindGameObjectsWithTag("Heart")[0];
        heartUi.SetActive(false);

        invulnerable = true;
        yield return new WaitForSeconds(invulerabilityDelay);
        invulnerable = false;
    }
}
