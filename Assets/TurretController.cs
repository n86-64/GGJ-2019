using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private List<GameObject> bullets;
    private int amountToPool = 20;

    public float searchRadius = 10;
    public LayerMask enemyLayer;
    
    private List<GameObject> enemies = new List<GameObject>();

    public float rateOfFire = 1;
    private float timeElapsed = 0;

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
            if (Vector3.Distance(transform.position, enemy.transform.position) < previousDistance)
            {
                previousDistance = Vector3.Distance(transform.position, enemy.transform.position);
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            transform.parent.LookAt(closestEnemy.transform.position);
            Fire(closestEnemy);
        }
    }

    private void Fire(GameObject enemy)
    {
        if (timeElapsed > rateOfFire)
        {
            Bullet bullet = GetBullet().GetComponent<Bullet>();
            bullet.origin = transform.position;
            bullet.target = enemy.transform;
            bullet.gameObject.SetActive(true);

            timeElapsed = 0;
        }
        else
        {
            timeElapsed += Time.deltaTime;
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