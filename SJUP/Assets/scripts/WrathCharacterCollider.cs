using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathCharacterCollider : MonoBehaviour {

	float timeTillVurn = 0;
	public float iFrameTime = 2;
	public int Damage = 34;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			WrathEnemy enemy = coll.gameObject.GetComponent<WrathEnemy> ();
			GameObject body = GetComponent<Collider2D> ().gameObject;
			GameObject bodyParent = body.transform.parent.gameObject;
			bodyParent.GetComponent<WrathCharacter> ().DamagePlayer (Damage);
			Debug.Log ("Player took" + "34" + "damage.");
			WrathMaster.KillEnemy (enemy);
		}
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
			if (Time.time >= timeTillVurn) {
				timeTillVurn = Time.time + 1 / iFrameTime;
				GameObject body = GetComponent<Collider> ().gameObject;
				GameObject bodyParent = body.transform.parent.gameObject;
				bodyParent.GetComponent<WrathCharacter> ().DamagePlayer (Damage);
				Debug.Log ("Player took" + "34" + "damage.");
			}
		}
	}
}
