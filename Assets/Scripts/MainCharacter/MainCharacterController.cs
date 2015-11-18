using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting, Jumping, Dead, Start, Crushing, Crouching, GameOver};
    public float invulerabilityDelay;
    public float hitStopDelay;
    public float gameOverDelay;

    private States state = States.Start;
    public int heart = 3;
    private bool invulnerable = false;
    private Animator animator;
    private bool crushRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetState(States newState)
    {
        if (state == States.Dead) {
            if (newState == States.GameOver) {
                state = newState;
            }
            
            return;
        }

        state = newState;

        SwitchAnim();
    }

    public States GetState()
    {
        return state;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (state == States.Dead || state == States.GameOver) {
            return;
        }

        if (other.tag == "Ennemy")
        {
            var ennemyController = other.gameObject.GetComponent<EnnemyController>();
            if (ennemyController && state == States.Crushing && ennemyController.ennemyType == EnnemyController.EnnemyTypes.Tank) {
                // add score
                var scoreController = GameObject.FindGameObjectsWithTag("ScoreController")[0];
                scoreController.GetComponent<ScoreController>().AddScore(ennemyController.ennemyScore);

                return;
            }

            if (!invulnerable) {
                StartCoroutine(Hurt());
            }
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
            SetState(States.Dead);
            GetComponent<MainCharacterMover>().walkSpeed = 0.0f;
            GameObject gameOverUi = GameObject.FindGameObjectsWithTag("GameOver")[0];
            yield return new WaitForSeconds(gameOverDelay);
            gameOverUi.GetComponent<Text>().text = "GAME OVER";
            SetState(States.GameOver);
            yield return true;
        } else {
            animator.SetTrigger("hit");
            invulnerable = true;

            float lastWalkSpeed = GetComponent<MainCharacterMover>().walkSpeed;
            GetComponent<MainCharacterMover>().walkSpeed = 0.0f;
            yield return new WaitForSeconds(hitStopDelay);
            GetComponent<MainCharacterMover>().walkSpeed = lastWalkSpeed;

            yield return new WaitForSeconds(invulerabilityDelay);
            invulnerable = false;
        }
    }

    public void SwitchAnim()
    {
        switch(state)
        {
            case States.Jumping:
                animator.SetTrigger("jump");
                break;
            case States.Crushing:
                if (crushRight) {
                    animator.SetTrigger("crunchRight");
                } else {
                    animator.SetTrigger("crunchLeft");
                }
                crushRight = !crushRight;
                break;
            case States.Crouching:
                animator.SetTrigger("crouch");
                break;
            case States.Shooting:
                //animator.SetTrigger("fire");
                break;
            case States.Dead:
                animator.SetTrigger("die");
                break;
            default:
                break;
        }
    }
}
