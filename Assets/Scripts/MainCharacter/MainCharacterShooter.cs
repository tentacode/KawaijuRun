using UnityEngine;
using System.Collections;

public class MainCharacterShooter : MonoBehaviour
{
    public MainCharacterController mainCharacterController;
    public InputController inputController;
    public Transform spawnPoint;
    public GameObject projectile;
    public float speed;
    public float cooldown;
	
	void FixedUpdate ()
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

		Vector3 shootPoint;

		shootPoint = tapPosition;
        shootPoint = Camera.main.ScreenToWorldPoint(shootPoint);
		shootPoint = shootPoint - spawnPoint.position;

        float angle = Mathf.Atan(shootPoint.y / shootPoint.x);

        GameObject projectileInstance = Instantiate(projectile, spawnPoint.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
		projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed);

		StartCoroutine(Cooldown());
	}

	bool CanShoot()
	{
		return mainCharacterController.getState() == MainCharacterController.States.Idle;
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(cooldown);

		mainCharacterController.SetState(MainCharacterController.States.Idle);
	}
}
