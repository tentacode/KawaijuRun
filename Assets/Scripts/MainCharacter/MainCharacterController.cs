using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting, Jumping};
    private States state = States.Idle;

    public void SetState(States newState)
    {
        state = newState;
    }

    public States getState()
    {
        return state;
    }
}
