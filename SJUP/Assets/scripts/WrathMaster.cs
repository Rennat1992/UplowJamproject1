using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrathMaster : MonoBehaviour {
	
	public static WrathMaster WM;
	public GameObject enemy;
	public GameObject player;
	public Transform spawnPlayerPoint;
	public Transform[] spawnPoints;
	float spawnTime;
	public float waitTime = 3f;
	public static int killCount = 0;

	void Start ()
	{
		if (WM == null) {
			WM = GameObject.FindGameObjectWithTag ("GameController").GetComponent<WrathMaster> ();
		}
		spawnPlayer ();
		StartCoroutine (Waves ());
		StartCoroutine (shooterWaves ());
	}

	IEnumerator Waves ()
	{
		yield return new WaitForSeconds (waitTime);

		//wave 1
		while (killCount < 30) {
			Spawn ();
			spawnTime = Random.Range (2f, 5f);
			yield return new WaitForSeconds (spawnTime);
		}

		//wave 2
		while (killCount < (30 + 35)) {
			Spawn ();
			spawnTime = Random.Range (.5f, 2f);
			yield return new WaitForSeconds (spawnTime);
		}

		//wave 3
		while (killCount < (30 + 35 + 40)) {
			Spawn ();
			spawnTime = Random.Range (.5f, 1f);
			yield return new WaitForSeconds (spawnTime);
		}

		//wave 4
		while (killCount < (30 + 35 + 40 + 40)) {
			Spawn ();
			spawnTime = Random.Range (.5f, 1f);
			yield return new WaitForSeconds (spawnTime);
		}

		//wave 5
		while (killCount < (30 + 35 + 40 + 40 + 40)) {
			Spawn ();
			spawnTime = Random.Range (.5f, 1f);
			yield return new WaitForSeconds (spawnTime);
		}

		if (killCount >= (30 + 35 + 40 + 40 + 40)) {
			Debug.Log ("5 Waves complete, need a victory transitition");
		}
	}

	IEnumerator shooterWaves () {
		//wave 4
		while ((killCount < (30 + 35 + 40 + 40)) && (killCount > (30 + 35 + 40))) {
			SpawnShooter ();
			yield return new WaitForSeconds (3f);
		}

		//wave 5
		while ((killCount < (30 + 35 + 40 + 40 + 40)) && (killCount > (30 + 35 + 40 + 40))) {
			SpawnShooter ();
			yield return new WaitForSeconds (1f);
		}
	}

	void Spawn ()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

	void SpawnShooter ()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		GameObject g = Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation) as GameObject;
		WrathEnemy shooter = g.GetComponent<WrathEnemy> ();
		shooter.isShooter = true;
	}

	public static void KillPlayer (WrathCharacter player) {
		Destroy (player.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public static void KillEnemy (WrathEnemy enemy) {
		Destroy (enemy.gameObject);
		killCount++;
	}

	public void spawnPlayer()
	{
		Instantiate (player, spawnPlayerPoint.position, spawnPlayerPoint.rotation);
	}
}
