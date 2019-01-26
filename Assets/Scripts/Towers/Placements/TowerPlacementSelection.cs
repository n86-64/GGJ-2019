using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementSelection : MonoBehaviour
{
    public List<Tower> towersToSpawn;

    public void Test()
    {
        Debug.Log("wtf ain't this working");
    }

    public void SpawnTower(int index)
    {
        Debug.Log("Im spawning a tower m8");
        TowerBaseSelection selectionSystem = GameObject.FindObjectOfType<TowerBaseSelection>();
        TowerPlace spawnLocation = selectionSystem.getSelectedTowerPlace();
        Tower newTower = Instantiate(towersToSpawn[index], spawnLocation.transform.position, Quaternion.Euler(Vector3.zero));
        spawnLocation.placeTower(newTower); 
        selectionSystem.DeSelected();
    }


}
