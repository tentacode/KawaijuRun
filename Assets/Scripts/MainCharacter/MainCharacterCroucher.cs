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
    private BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        initialColliderSize = collider.size;
        initialColliderOffset = collider.offset;
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
        collider.size = new Vector2(
            collider.size.x + crouchDelta.x,
            collider.size.y + crouchDelta.y
        );
        collider.offset = new Vector2(
            collider.offset.x + (crouchDelta.x / 2),
            collider.offset.y + (crouchDelta.y / 2)
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

        collider.size = initialColliderSize;
        collider.offset = initialColliderOffset;

        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
