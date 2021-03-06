﻿using UnityEngine;
using System.Collections;

//Place this on any object to make it move across the level as an enemy
public class Movement : MonoBehaviour
{
    public MovementController routeController;
    private Rigidbody rb;
    private Enemy enemy;

    public AudioSource engineSound;
    public AudioSource engineFire;

    public Vector3 moveToPoint;
    public Vector3 offsetToPoint;
    public Vector3 directionToPoint;
    public int currentPointIndex;

    public float maxSpeed = 8.0f;
    public float acceleration = 8.0f;

    public float distanceFromPointCheck; //How close to the next point before going to next position
    private float rotationSpeed; //The speed the unit rotates to head towards the point;
    public bool canMove;

    public bool dying = false;

    private void Start()
    {
        AudioManager.instance.PlaySFX(engineSound,AudioManager.instance.engineSound);
        //routeController = GameObject.FindGameObjectWithTag("MasterPositions").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
        rotationSpeed = enemy.GetMoveSpeed() / 2;

        moveToPoint = routeController.masterPositions[currentPointIndex].position;

    }

    void FixedUpdate()
    {
        Move();
    }

    void CheckNextPoint()
    {
        if (!gameObject.activeInHierarchy)
            return;

        currentPointIndex++;
        
        if (currentPointIndex >= routeController.masterPositions.Count)
        {
            TempRemoveUnit();
            return;
        }
        else
        {
            moveToPoint = routeController.masterPositions[currentPointIndex].position;
            offsetToPoint = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        }
    }

    void RotateTowardsPoint()
    {
        //Vector3 lookAtGoal = new Vector3(moveToPoint.x, transform.position.y, moveToPoint.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToPoint), Time.deltaTime * rotationSpeed);   
    }


    void Move()
    {
        if (canMove)
        {
            RotateTowardsPoint();
            directionToPoint = (new Vector3(moveToPoint.x, transform.position.y, moveToPoint.z) + offsetToPoint) - new Vector3(transform.position.x, 0, transform.position.z);


            if (rb.velocity.magnitude <= maxSpeed && !dying)
            {
                rb.AddRelativeForce(new Vector3(0, 0, acceleration) - rb.velocity);
            }

            //Vector3.ClampMagnitude(rb.velocity, 10);


            if (Vector3.Distance(transform.position, new Vector3(moveToPoint.x, transform.position.y, moveToPoint.z)) <= distanceFromPointCheck)
            {
                CheckNextPoint();
            }
        }
    }

    //This would remove the enemy and do something like add point. To be replaced by a different system.
    void TempRemoveUnit()
    {
        //Add points
        print("Enemy should die");

        Debug.Log(WaveController.instance.activeUnits);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
