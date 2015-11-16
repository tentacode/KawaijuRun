using UnityEngine;
using System.Collections;

public class MainCharacterCroucher : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float cooldown;
    public Vector2 crouchDelta;

    private Vector2 initialColliderSize;
    private Vector2 initialColliderOffset;
    private BoxCollider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        initialColliderSize = playerCollider.size;
        initialColliderOffset = playerCollider.offset;
    }
    
    void FixedUpdate ()
    {
        if (!CanCrouch()) {
            return;
        }

        if (!inputController.IsSwipeDown()) {
            return;
        }

        Crouch();
    }

    void Crouch()
    {
        mainCharacterController.SetState(MainCharacterController.States.Crouching);
        playerCollider.size = new Vector2(
            playerCollider.size.x + crouchDelta.x,
            playerCollider.size.y + crouchDelta.y
        );
        playerCollider.offset = new Vector2(
            playerCollider.offset.x + (crouchDelta.x / 2),
            playerCollider.offset.y + (crouchDelta.y / 2)
        );

        StartCoroutine(Cooldown());
    }

    bool CanCrouch()
    {
        return mainCharacterController.GetState() == MainCharacterController.States.Idle;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);

        playerCollider.size = initialColliderSize;
        playerCollider.offset = initialColliderOffset;

        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
