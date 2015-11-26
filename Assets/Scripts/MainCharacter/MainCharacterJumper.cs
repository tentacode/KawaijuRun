using UnityEngine;
using System.Collections;

public class MainCharacterJumper : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float jumpForce;
    public float jumpSpeed;
    public float cooldown;
    
    private Rigidbody2D rb;
    private MainCharacterMover playerMover;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMover = GetComponent<MainCharacterMover>();
    }
    
    void Update ()
    {
        if (!CanJump()) {
            return;
        }

        if (!inputController.IsSwipeUp()) {
            return;
        }

        Jump();
    }

    void Jump()
    {
        mainCharacterController.SetState(MainCharacterController.States.Jumping);
        playerMover.walkSpeed = jumpSpeed;
        rb.AddForce(new Vector2(0.0f, jumpForce));

        StartCoroutine(Cooldown());
    }

    bool CanJump()
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
