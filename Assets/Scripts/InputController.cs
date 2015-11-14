using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown("up")) {
			Debug.Log ("Slide up");
		}
		if (Input.GetKeyDown("down")) {
			Debug.Log ("Slide down");
		}
		if (Input.GetKeyDown("right")) {
			Debug.Log ("Slide right");
		}
	}
}
