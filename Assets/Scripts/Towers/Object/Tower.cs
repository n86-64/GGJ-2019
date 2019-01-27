using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Properties.
    public float cost = 50.0f;
    public float searchRadius = 10;
    public float timeBetweenShots = 1;

    [SerializeField]
    protected List<GameObject> enemies = new List<GameObject>();
    protected float timeElapsed = 0;

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

        if (other.tag == "Player")
        {

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