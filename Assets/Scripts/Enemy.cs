using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    RATS, BURGLARS, CLUBBERS
}

public class Enemy : MonoBehaviour
{

    public AudioSource fireSoundSource;
    public AudioSource engineSoundSource;

    [HideInInspector]
    public EnemyType type;
    [HideInInspector]
    public Vector3 origin;
    [HideInInspector]
    public Vector3 offsetPosition;

    public int health = 10;
    public float damage = 3.0f;
    public int moveSpeed = 20;

    public int lifetime = 100;

    public int ticksTilDamaged = 100;

    private int damageTicks = 0; 
    
    private Vector3 checkPos;
    private float timeStill;
    private float timeMoving;

    public float reward = 4.0f;

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
            BlowUpCar();
        }

        if (Input.GetKey("m"))
        {
            BlowUpCar();
        }

        if (Vector3.Distance(transform.position, checkPos) < 1)
        {
            timeStill += Time.deltaTime;
            if (timeStill > 10)
            {
                health = 0;
            }
        }
        else
        {
            timeMoving += Time.deltaTime;
            if (timeMoving > 1)
            {
                checkPos = transform.position;
                timeMoving = 0;
            }
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

            //Debug.Log("Ow, HP left: " + health);
        }
        else
        {
            health = 0;
            GameObject.FindGameObjectWithTag("Objectives").GetComponent<ObjectiveData>().addMoney(reward);

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
        BlowUpCar();
    }

    private void BlowUpCar()
    {
        // enable particle effects (and play)
        AudioManager.instance.PlaySFX(fireSoundSource, AudioManager.instance.fireSound);
        AudioManager.instance.StopSFX(engineSoundSource);
       
        StartCoroutine(GetComponent<CarBlowUp>().Particles());
        StartCoroutine(GetComponent<CarBlowUp>().ShrinkCar());

        GetComponent<Movement>().dying = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<ObjectiveData>())
        {
            collider.gameObject.GetComponent<ObjectiveData>().TakeDamage(damage);
        }
        
    }
}
   
