using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathMaster : MonoBehaviour {

	public static void KillPlayer (WrathCharacter player) {
		Destroy (player.gameObject);
	}
	public static void KillEnemy (WrathEnemy enemy) {
		Destroy (enemy.gameObject);
	}
}
