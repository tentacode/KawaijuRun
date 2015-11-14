using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	const string DIRECTION_UP = "up";
	const string DIRECTION_DOWN = "down";
	const string DIRECTION_RIGHT = "right";

	public float tapScreenSplitRatio;
	public float mininmumSwipeMagnitude;

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
		
		if (IsTapBottom()) {
			Debug.Log ("Tap bottom");
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

		return direction == GetSlidingDirection();
	}

	string GetSlidingDirection()
	{
		if (Input.touchCount == 0) {
			return null;
		}

		var touch = Input.GetTouch(0);
		if (touch.phase == TouchPhase.Began) {
			swipeBeginPosition = touch.position;
			return null;
		}

		if (touch.phase == TouchPhase.Ended) {
			Vector2 deltaPosition = touch.position - swipeBeginPosition;
			if (deltaPosition.magnitude < mininmumSwipeMagnitude) {
				return null;
			}

			var angle = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;

			if (angle < 135 && angle >= 45) {
				return DIRECTION_UP;
			}

			if (angle < 45 && angle >= -45) {
				return DIRECTION_RIGHT;
			}

			if (angle < -45 && angle >= -135) {
				return DIRECTION_DOWN;
			}
		}
		
		return null;
	}
	
	bool IsTapBottom()
	{
		Vector2 position;
		if (Input.GetButtonUp("Fire1") && null == GetSlidingDirection()) {
			position = Input.mousePosition;
			float splitPosition = Screen.height * tapScreenSplitRatio;
			
			return position.y < splitPosition;
		}
		
		return false;
	}
	
	bool IsTapUp()
	{
		Vector2 position;
		if (Input.GetButtonUp("Fire1") && null == GetSlidingDirection()) {
			position = Input.mousePosition;
			float splitPosition = Screen.height * tapScreenSplitRatio;
			
			return position.y >= splitPosition;
		}
		
		return false;
	}
}
