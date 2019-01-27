using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Tower
{
    public GameObject gun; 
    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;
    private List<GameObject> bullets;
    private int amountToPool = 20;

    private void Start()
    {
        bullets = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, transform);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    private void FixedUpdate()
    {
        if (enemies.Count == 0)
            return;

        float previousDistance = 100;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < previousDistance)
                {
                    previousDistance = Vector3.Distance(transform.position, enemy.transform.position);
                    closestEnemy = enemy;
                }
            }
            else
            {
                previousDistance = 100;
            }
        }

        if (closestEnemy != null)
        {
            gun.transform.LookAt(closestEnemy.transform.position);
            Fire(closestEnemy);
        }
    }

    private void Fire(GameObject enemy)
    {
        if (timeElapsed > timeBetweenShots)
        {
            Bullet bullet = GetBullet().GetComponent<Bullet>();
            bullet.origin = bulletSpawnPosition.position;
            bullet.target = enemy.transform;
            bullet.gameObject.SetActive(true);

            timeElapsed = 0;
        }
        else
        {
            timeElapsed += Time.deltaTime;
        }
    }

    private GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }  
        return null;
    }
}