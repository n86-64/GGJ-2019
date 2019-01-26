using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAOEController : Tower
{
    public ParticleSystem psFreeze;

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
        Debug.Log(other.tag);

        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy");

            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
            }
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