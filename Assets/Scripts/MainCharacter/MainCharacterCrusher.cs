using UnityEngine;
using System.Collections;

public class MainCharacterCrusher : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float cooldown;
    public float crushSpeed;

    private MainCharacterMover playerMover;
    
    void Start()
    {
        playerMover = GetComponent<MainCharacterMover>();
    }

    void Update ()
    {
        if (!CanCrush()) {
            return;
        }

        if (!inputController.IsTapBottom()) {
            return;
        }

        Crush();
    }

    void Crush()
    {
        playerMover.walkSpeed = crushSpeed;

        mainCharacterController.SetState(MainCharacterController.States.Crushing);

        StartCoroutine(Cooldown());
    }

    bool CanCrush()
    {
        return mainCharacterController.GetState() == MainCharacterController.States.Idle;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);

        playerMover.ResetSpeed();
        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
