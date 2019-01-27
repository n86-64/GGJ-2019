using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField]
    private float money = 100.0f;
    private float rent = 0.0f;

    private int lives = 0;

    [SerializeField]
    private GameObject gameOverMenu;

    // Use this for initialization
    void Start()
    {
        gameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (money <= 0.0f || Input.GetKeyDown(KeyCode.K))
        {
            HaveTheRent();
        }
    }

    void HaveTheRent()
    {
        if (money <= rent || Input.GetKeyDown(KeyCode.K))
        {
            // might have lives here

            // would have to set it somewhere else, here is fine to clear a console warning
            lives = 1;
            
            // remove a life for not paying rent
            if (lives > 1)
            {
                lives--;
            }
            else
            {
                // add the lines below up here, duh
            }

            // Im Dead end the game.
            Debug.Log("Oh No Were bankrupt.");
            gameOverMenu.SetActive(true);
        }
        else
        {
            money -= rent;
        }
    }

    public float getQuota()
    {
        return rent;
    }

    public float getMoney()
    {
        return money;
    }

    public void addMoney(float amount)
    {
        money += amount;
    }

    public void TakeDamage(float damage)
    {
        // Here we will take damage. 
        money -= damage;
    }
}
