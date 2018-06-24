using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathEnemy : MonoBehaviour {


	public Transform player;
	public float moveSpeed = 3.0f;
	public int rotationOffset = 270;

	[System.Serializable]
	public class EnemyStats {
		public int Health = 33;
	}

	public EnemyStats stats = new EnemyStats();

	public void DamageEnemy (int damage) {
		stats.Health -= damage;
		if (stats.Health <= 0) {
			WrathMaster.KillEnemy (this);
		}
	}

	void Start ()
	{
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update ()
	{
		Vector2 difference = player.position - transform.position;		//subtracting the position of the player from the mouse position
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		transform.position += transform.up * moveSpeed * Time.deltaTime;
	}
}
