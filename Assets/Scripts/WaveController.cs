using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave[] waves;

    [HideInInspector]
    public int currentWave = 0;


    public void SpawnNextWave()
    {
        ActivateWaveUI();

        currentWave++;
        Wave newWave = waves[currentWave];

        for(int i = 0; i < newWave.numberToSpawn; i++)
        {
            GameObject unit = Instantiate(newWave.prefab);
            //instantiate as an enemy type
            //add behaviour to it based on type
            //new list of units?
        }
    }

    private void ActivateWaveUI()
    {

    }
	
}
