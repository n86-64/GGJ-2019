using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Properties.
    public float searchRadius = 10;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    public float timeBetweenShots = 1;
    private float timeElapsed = 0;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
