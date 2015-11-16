using UnityEngine;
using System.Collections;

public class MainCharacterCrusher : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float cooldown;
    public float crushSpeed;

    private float playerSpeed;
    private MainCharacterMover playerMover;
    
    void Start()
    {
        playerMover = GetComponent<MainCharacterMover>();
    }

    void FixedUpdate ()
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
        playerSpeed = playerMover.walkSpeed;
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

        playerMover.walkSpeed = playerSpeed;
        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
