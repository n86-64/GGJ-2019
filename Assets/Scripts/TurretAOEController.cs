﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAOEController : MonoBehaviour
{
    public ParticleSystem psFreeze;

    public float searchRadius = 10;
    
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    public float timeBetweenShots = 1;
    private float timeElapsed = 0;

    private void FixedUpdate()
    {
        if (enemies.Count == 0)
        {
            return;
        }
        
        float previousDistance = 100;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < previousDistance)
            {
                previousDistance = Vector3.Distance(transform.position, enemy.transform.position);
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            transform.parent.LookAt(new Vector3(closestEnemy.transform.position.x, transform.position.y, closestEnemy.transform.position.z));
            Fire();
        }
    }

    private void Fire()
    {
        if (timeElapsed > timeBetweenShots)
        {
            psFreeze.Play();

            timeElapsed = 0;
        }
        else
        {
            timeElapsed += Time.deltaTime;
        }

        foreach (GameObject enemy in enemies)
        {
            // enemy.TakeDamage(damage);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!enemies.Contains(other.gameObject))
                enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}