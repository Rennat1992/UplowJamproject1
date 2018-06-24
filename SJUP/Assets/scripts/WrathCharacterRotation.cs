using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathCharacterRotation : MonoBehaviour {
	public int rotationOffset = 270;
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;		//subtracting the position of the player from the mouse position
		difference.Normalize ();		// normalizing the vector meaning that all the sum of the vector will be equal to 1.

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
	}
}
