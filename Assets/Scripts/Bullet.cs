using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public Vector3 origin;
    public float bulletSpeed = 0.5f;


    private void OnEnable()
    {
        transform.position = origin;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Weapon")
        {
            Debug.Log("Bullet hit something");
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }
}

