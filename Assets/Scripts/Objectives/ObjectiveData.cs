using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveData : MonoBehaviour
{
    [SerializeField]
    public float money = 100.0f;
    public float rent = 0.0f;

    public int lives = 2;

    [SerializeField]
    private GameObject gameOverMenu;
    
    void Start()
    {
        gameOverMenu = GameObject.FindGameObjectWithTag("GameOver");
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.M))
        {
            money += 10.0f;
        }
        else if(Input.GetKey(KeyCode.N))
        {
            money -= 10.0f;
        }
#endif


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
