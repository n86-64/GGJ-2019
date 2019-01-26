using System.Collections;
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
    public Vector3 offsetPosition;

    private int health = 10;
    private int damage = 2;
    private int moveSpeed = 20;

    private void Awake()
    {
        transform.position += offsetPosition;

        switch (type)
        {
            case EnemyType.RATS:
                health = 10;
                damage = 2;
                moveSpeed = 20;
                break;
            case EnemyType.BURGLARS:
                health = 10;
                damage = 2;
                moveSpeed = 20;
                break;
            case EnemyType.CLUBBERS:
                health = 10;
                damage = 2;
                moveSpeed = 20;
                break;
        }
    }

    public int GetMoveSpeed()
    {
        return moveSpeed;
    }
}