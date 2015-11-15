using UnityEngine;
using System.Collections;

public class MainCharacterCrusher : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public float cooldown;
    
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
        mainCharacterController.SetState(MainCharacterController.States.Crushing);

        StartCoroutine(Cooldown());
    }

    bool CanCrush()
    {
        return mainCharacterController.getState() == MainCharacterController.States.Idle;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);

        mainCharacterController.SetState(MainCharacterController.States.Idle);
    }
}
