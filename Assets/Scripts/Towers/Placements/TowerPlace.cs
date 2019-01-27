using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public GameObject spawnPos;
    private Tower currentSelectedTower;

    // Place a tower.
    public void placeTower(Tower newTower)
    {
        if(currentSelectedTower == null)
        {
            currentSelectedTower = newTower;
            currentSelectedTower.transform.position = spawnPos.transform.position;
        }
    }

    public bool hasTower()
    {
        return currentSelectedTower != null;
    }

    void clearTower()
    {
        // TODO - Destroy the tower. 
        currentSelectedTower = null;
    }
}
