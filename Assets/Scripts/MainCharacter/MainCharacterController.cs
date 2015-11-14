using UnityEngine;
using System.Collections;

public class MainCharacterController : MonoBehaviour
{
    public enum States {Idle, Shooting};
    private States state = States.Idle;
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetState(States newState)
    {
        state = newState;
    }

    public States getState()
    {
        return state;
    }
}
