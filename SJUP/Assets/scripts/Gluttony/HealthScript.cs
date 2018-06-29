using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    [System.Serializable]
    public class EnemyStats
    {
        public int Health = 13;
        public float fireRate = 1.5f;
    }

    public EnemyStats stats = new EnemyStats();

    public void DamageEnemy(int damage)
    {
        stats.Health -= damage;
        if (stats.Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}