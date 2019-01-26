using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    [SerializeField]
    private float health = 100;

    [SerializeField]
    private GameObject gameOverMenu;

    public float maxHealth = 100;

	// Use this for initialization
	void Start ()
    {
        gameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        gameOverMenu.SetActive(false); 
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(health <= 0.0f || Input.GetKeyDown(KeyCode.K))
        {
            Dead();
        }
	}

    void Dead()
    {
        // Im Dead end the game.
        Debug.Log("Were dead mate");
        gameOverMenu.SetActive(true);
        // Stop the enemies. Maybe get them to do a little dance.
    }

    public void TakeDamage(float damage)
    {
        // Here we will take damage. 
        health -= damage;
        health = Mathf.Clamp(health, 0.0f, maxHealth);
    }
}
