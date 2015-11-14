using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting, Jumping};
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
}
