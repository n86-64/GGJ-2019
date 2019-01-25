using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType
{
    LANDLORD, YOUTHS
}

[Serializable]
public class Wave
{
    public EnemyType enemyType;
    public int numberToSpawn;

    //May be determined by their speed
    public int timeActive;

    //Multiplier on their stats
    public int strength;

    public GameObject prefab;
}
