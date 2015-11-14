using UnityEngine;
using System.Collections;

public class MainCharacterShooter : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public Transform spawnPoint;
    public GameObject projectile;
    public float speed;
	
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

		 Vector3 shootDirection;
		 shootDirection = tapPosition;
		 shootDirection.z = 0.0f;
		 shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
		 shootDirection = shootDirection - spawnPoint.position;

		 GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
		 Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
		 rb.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
	}

	bool CanShoot()
	{
		return mainCharacterController.getState() == MainCharacterController.States.Idle;
	}
}
