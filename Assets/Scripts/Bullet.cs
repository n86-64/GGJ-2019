using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public Vector3 origin;
    public float bulletSpeed = 0.5f;
    public int damage = 3;

    private void OnEnable()
    {
        transform.position = origin;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().getHit(damage);

            //Debug.Log("Bullet hit something");
            gameObject.SetActive(false);
        }
        else if (other.tag != "Weapon")
        {
            //Debug.Log("Bullet hit something");
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);

            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }
}

