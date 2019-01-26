using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    [SerializeField]
    private int health = 100;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            TakeDamage(other.GetComponent<Enemy>());   
            // Just disable the enemy.
        }    
    }

    void Dead()
    {
        // Im Dead end the game.
        return;
    }

    void TakeDamage(Enemy enemy)
    {
        // Here we will take damage. 
    }
}
