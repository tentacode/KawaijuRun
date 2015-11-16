using UnityEngine;
using System.Collections;

public class MainCharacterJumper : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float jumpForce;
    public float cooldown;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate ()
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

        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
