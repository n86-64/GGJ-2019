using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Properties.
    public float searchRadius = 10;
    public float timeBetweenShots = 1;

    [SerializeField]
    protected List<GameObject> enemies = new List<GameObject>();
    protected float timeElapsed = 0;
}
