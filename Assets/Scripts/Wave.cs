using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemySpawn
{
    public EnemyType type;
    public int count;
    public int intervalUntilNext;
}

[Serializable]
public class Wave
{
    public EnemySpawn[] enemies;

    //May be determined by their speed
    public int timeBeforeNextSpawn;

    //Multiplier on their stats
    public int strength;

    public GameObject prefab;

    public int totalToSpawn
    {
        get
        {
            int total = 0;
            for(int i = 0; i < enemies.Length; i ++)
            {
                total += enemies[i].count;
            }
            return total;
        }
    }
}
