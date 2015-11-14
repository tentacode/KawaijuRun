using UnityEngine;
using System.Collections;

public class MainCharacterShooter : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public Transform spawnPoint;
    public GameObject projectile;
	
	void Update ()
	{
		if (!CanShoot()) {
			return;
		}
		
		Vector2? tapPosition = inputController.GetTapUpPosition();
		if (!tapPosition.HasValue) {
			return;
		}

		Shoot(tapPosition.Value);
	}

	void Shoot(Vector2 tapPosition)
	{
		mainCharacterController.SetState(MainCharacterController.States.Shooting);
	}

	bool CanShoot()
	{
		return mainCharacterController.getState() == MainCharacterController.States.Idle;
	}
}
