using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    //Singleton Motherfuckers!!!
    public static HealthScript HealthScriptSingle;

    void Awake()
    {
        if (HealthScriptSingle == null)
        {
            //DontDestroyOnLoad(gameObject);
            HealthScriptSingle = this;
        }
        else if (HealthScriptSingle != this)
        {
            Destroy(gameObject);
        }

        //currentQuest = 0f;
    }


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