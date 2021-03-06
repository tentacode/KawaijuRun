﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	const string DIRECTION_UP = "up";
	const string DIRECTION_DOWN = "down";
	const string DIRECTION_RIGHT = "right";

	public Camera mainCamera;
	public Transform spawnPoint;
	public float tapScreenSplitRatio;
	public float mininmumSwipeMagnitude;

	private Vector2 swipeBeginPosition;

	void Update()
	{
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				swipeBeginPosition = touch.position;
			}
		}

		// if (IsSwipeUp()) {
		// 	Debug.Log ("Swipe up");
		// }

		// if (IsSwipeDown()) {
		// 	Debug.Log ("Swipe down");
		// }

		// if (IsSwipeRight()) {
		// 	Debug.Log ("Swipe right");
		// }
		
		// if (IsTapBottom()) {
		// 	Debug.Log ("Tap bottom");
		// }
		
		// if (GetTapUpPosition().HasValue) {
		// 	Debug.Log ("Tap up");
		// }
	}
	
	public bool IsTap()
	{
		return Input.GetButtonUp("Fire1");
	}
	
	public bool IsSwipeUp()
	{
		return IsSwipe(DIRECTION_UP);
	}
	
	public bool IsSwipeDown()
	{
		return IsSwipe(DIRECTION_DOWN);
	}
	
	public bool IsSwipeRight()
	{
		return IsSwipe(DIRECTION_RIGHT);
	}
	
	public bool IsTapBottom()
	{
		Vector2 position;
		if (Input.GetButtonUp("Fire1") && null == GetSlidingDirection()) {
			position = Input.mousePosition;
			float splitPosition = Screen.height * tapScreenSplitRatio;
			
			return position.y < splitPosition;
		}
		
		return false;
	}
	
	public Vector2? GetTapUpPosition()
	{
		Vector2 position;
		if (Input.GetButtonUp("Fire1") && null == GetSlidingDirection()) {
			position = Input.mousePosition;

			//cannot tap bellow screen
			float splitPosition = Screen.height * tapScreenSplitRatio;
			if (position.y < splitPosition) {
				return null;
			}

			//cannot tap behind spawnPoint
			Vector3 eyeScreenPosition = mainCamera.WorldToScreenPoint(spawnPoint.position);
			if (position.x < eyeScreenPosition.x) {
				return null;
			}
				
			return position;
		}
		
		return null;
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

		if (touch.phase != TouchPhase.Ended) {
			return null;
		}

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
		
		return null;
	}
}
