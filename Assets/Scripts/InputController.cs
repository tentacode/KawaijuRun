using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	public float tapScreenSplitRatio;

	void Update()
	{
		if (IsSlideUp()) {
			Debug.Log ("Slide up");
		}

		if (IsSlideDown()) {
			Debug.Log ("Slide down");
		}

		if (IsSlideRight()) {
			Debug.Log ("Slide right");
		}
		
		if (IsTapDown()) {
			Debug.Log ("Tap down");
		}
		
		if (IsTapUp()) {
			Debug.Log ("Tap up");
		}
	}
	
	bool IsSlideUp()
	{
		if (Input.GetKeyDown("up")) {
			return true;
		}
		
		return false;
	}
	
	bool IsSlideDown()
	{
		if (Input.GetKeyDown("down")) {
			return true;
		}
		
		return false;
	}
	
	bool IsSlideRight()
	{
		if (Input.GetKeyDown("right")) {
			return true;
		}
		
		return false;
	}

	bool IsTapDown()
	{
		Vector2 position;
		if (Input.GetButtonDown("Fire1")) {
			position = Input.mousePosition;

			return this.isPositionBottom(position);
		}
		
		return false;
	}
	
	bool IsTapUp()
	{
		Vector2 position;
		if (Input.GetButtonDown("Fire1")) {
			position = Input.mousePosition;
			
			return this.isPositionTop(position);
		}
		
		return false;
	}
	
	bool isPositionBottom(Vector2 position)
	{
		float splitPosition = Screen.height * tapScreenSplitRatio;

		return position.y < splitPosition;
	}
	
	bool isPositionTop(Vector2 position)
	{
		float splitPosition = Screen.height * tapScreenSplitRatio;
		
		return position.y >= splitPosition;
	}
}
