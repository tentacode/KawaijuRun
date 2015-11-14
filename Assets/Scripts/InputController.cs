using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	const string DIRECTION_UP = "up";
	const string DIRECTION_DOWN = "down";
	const string DIRECTION_RIGHT = "right";

	public float tapScreenSplitRatio;

	private Vector2 swipeBeginPosition;

	void Update()
	{
		if (IsSwipeUp()) {
			Debug.Log ("Swipe up");
		}

		if (IsSwipeDown()) {
			Debug.Log ("Swipe down");
		}

		if (IsSwipeRight()) {
			Debug.Log ("Swipe right");
		}
		
		if (IsTapDown()) {
			Debug.Log ("Tap down");
		}
		
		if (IsTapUp()) {
			Debug.Log ("Tap up");
		}
	}
	
	bool IsSwipeUp()
	{
		return IsSwipe(DIRECTION_UP);
	}
	
	bool IsSwipeDown()
	{
		return IsSwipe(DIRECTION_DOWN);
	}
	
	bool IsSwipeRight()
	{
		return IsSwipe(DIRECTION_RIGHT);
	}

	bool IsSwipe(string direction)
	{
		if (Input.GetKeyDown(direction)) {
			return true;
		}

		if (Input.touchCount == 0) {
			return false;
		}

		var touch = Input.GetTouch(0);
		if (touch.phase == TouchPhase.Began) {
			swipeBeginPosition = touch.position;
			return false;
		}

		if (touch.phase == TouchPhase.Ended) {
			Vector2 deltaPosition = touch.position - swipeBeginPosition;
			var angle = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;

			if (direction == DIRECTION_UP && angle < 135 && angle >= 45) {
				return true;
			}

			if (direction == DIRECTION_RIGHT && angle < 45 && angle >= -45) {
				return true;
			}

			if (direction == DIRECTION_DOWN && angle < -45 && angle >= -135) {
				return true;
			}
		}
		
		return false;
	}
	
	bool IsTapDown()
	{
		Vector2 position;
		if (Input.GetButtonDown("Fire1")) {
			position = Input.mousePosition;
			float splitPosition = Screen.height * tapScreenSplitRatio;
			
			return position.y < splitPosition;
		}
		
		return false;
	}
	
	bool IsTapUp()
	{
		Vector2 position;
		if (Input.GetButtonDown("Fire1")) {
			position = Input.mousePosition;
			float splitPosition = Screen.height * tapScreenSplitRatio;
			
			return position.y >= splitPosition;
		}
		
		return false;
	}
}
