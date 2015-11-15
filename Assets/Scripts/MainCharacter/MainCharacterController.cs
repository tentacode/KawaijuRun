using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting, Jumping, Dead, Start, Crushing, Crouching};
    public float invulerabilityDelay;
    public float gameOverDelay;

    private States state = States.Start;
    public int heart = 3;
    private bool invulnerable = false;

    public void SetState(States newState)
    {
        Debug.Log("New state: " + newState);
        state = newState;
    }

    public States getState()
    {
        return state;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (invulnerable || state == States.Dead) {
            return;
        }

        if (other.tag == "Ennemy")
        {
            var ennemyController = other.gameObject.GetComponent<EnnemyController>();
            if (ennemyController && state == States.Crushing && ennemyController.ennemyType == EnnemyController.EnnemyTypes.Tank) {
                return;
            }

            StartCoroutine(Hurt());
        }
    }

    IEnumerator Hurt()
    {
        heart--;

        var heartUis = GameObject.FindGameObjectsWithTag("Heart");
        if (heartUis.Length > 0) {
            GameObject heartUi = heartUis[0];
            heartUi.SetActive(false);
        }

        if (heart == 0) {
            state = States.Dead;
            GetComponent<MainCharacterMover>().walkSpeed = 0.0f;
            GameObject gameOverUi = GameObject.FindGameObjectsWithTag("GameOver")[0];
            yield return new WaitForSeconds(gameOverDelay);
            gameOverUi.GetComponent<Text>().text = "GAME OVER";
            yield return true;
        }

        invulnerable = true;
        yield return new WaitForSeconds(invulerabilityDelay);
        invulnerable = false;
    }
}
