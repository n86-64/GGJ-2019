﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    RATS, BURGLARS, CLUBBERS
}

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public EnemyType type;
    [HideInInspector]
    public Vector3 origin;
    [HideInInspector]
    public Vector3 offsetPosition;

    private int health = 10;
    private int damage = 2;
    private int moveSpeed = 20;

    private int lifetime = 100;

    private void Awake()
    {
        transform.position = origin + offsetPosition;

        switch (type)
        {
            case EnemyType.RATS:
                health = 10;
                damage = 2;
                moveSpeed = 15;
                break;
            case EnemyType.BURGLARS:
                health = 10;
                damage = 2;
                moveSpeed = 15;
                break;
            case EnemyType.CLUBBERS:
                health = 10;
                damage = 2;
                moveSpeed = 15;
                break;
        }

        StartCoroutine(DestroyAfterLifetime());
    }

    public int GetMoveSpeed()
    {
        return moveSpeed;
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}