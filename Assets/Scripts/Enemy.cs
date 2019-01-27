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
    public Vector3 origin;
    [HideInInspector]
    public Vector3 offsetPosition;

    public int health = 10;
    public int damage = 2;
    public int moveSpeed = 20;

    public int lifetime = 100;

    public int ticksTilDamaged = 100;

    private int damageTicks = 0;

    private void Awake()
    {
        transform.position = origin + offsetPosition;

        //switch (type)
        //{
        //    case EnemyType.RATS:
        //        health = 200;
        //        damage = 2;
        //        moveSpeed = 15;
        //        break;
        //    case EnemyType.BURGLARS:
        //        health = 10;
        //        damage = 2;
        //        moveSpeed = 15;
        //        break;
        //    case EnemyType.CLUBBERS:
        //        health = 10;
        //        damage = 2;
        //        moveSpeed = 15;
        //        break;
        //}

        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void getHit(int damage)
    {
        if (damage < health)
        {
            health -= damage;

            Debug.Log("Ow, HP left: " + health);
        }
        else
        {
            health = 0;

            Debug.Log("RIP");
        }
    }

    public void GetMicroHit()
    {
        damageTicks++;

        if (damageTicks > ticksTilDamaged)
        {
            damageTicks = 0;

            getHit(1);
        }
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}