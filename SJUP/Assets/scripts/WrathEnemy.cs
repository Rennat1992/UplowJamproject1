using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathEnemy : MonoBehaviour {

	public bool isShooter = false;
	public Transform player;
	public int rotationOffset = 270;

	float timeToFire = 0;
	Transform firePoint;
	public Transform BulletTrailPrefab;

	[System.Serializable]
	public class EnemyStats {
		public int Health = 33;
		public float moveSpeed = 3.0f;
		public float fireRate = 1.5f;
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
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("ERROR: FirePoint not found. You need a child object called FirePoint");
		}
	}

	void Update ()
	{
		Vector2 difference = player.position - transform.position;		//subtracting the position of the player from the mouse position
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		transform.position += transform.up * stats.moveSpeed * Time.deltaTime;

		if (isShooter) {
			if (Time.time > timeToFire) {
				timeToFire = Time.time + 1 / stats.fireRate;
				Shoot ();
			}
		}
	}

	void Shoot() {
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
