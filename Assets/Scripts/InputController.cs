using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	public float tapScreenSplitRatio = 0.66f;

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
		if (Input.GetButtonDown("Fire1")) {

			Debug.Log(Input.mousePosition);

			return true;
		}
		
		return false;
	}
	
	bool IsTapUp()
	{
		return false;
	}
}
