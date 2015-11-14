using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;

    void Update () 
    {
        if (mainCharacterController.getState() == MainCharacterController.States.Dead && inputController.IsTap()) {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
