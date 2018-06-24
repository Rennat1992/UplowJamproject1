﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathMoveBulletTrail : MonoBehaviour {

	public int moveSpeed = 330;
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		Destroy (this.gameObject, 1);
	}
}
