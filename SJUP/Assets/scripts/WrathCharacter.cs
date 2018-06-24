using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathCharacter : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int Health = 100;
	}

	public PlayerStats playerStats = new PlayerStats();

	public void DamagePlayer (int damage) {
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			WrathMaster.KillPlayer (this);
		}
	}
}
