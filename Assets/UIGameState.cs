using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameState : MonoBehaviour
{
    private ObjectiveData levelObjective;

    // properties
    public GameObject quotaCount;
    public GameObject quotaBar;
    public GameObject moneyCount;
    public GameObject waveCount;

    void Start()
    {
        levelObjective = FindObjectOfType<ObjectiveData>();
    }

    void Update ()
    {
        UpdateQuota();
        UpdateMoney();
        UpdateWaveCount();
	}

    void UpdateQuota()
    {
        if (levelObjective)
        {
            quotaCount.GetComponent<Text>().text = "QUOTA $" + Math.Round(levelObjective.getQuota(), 2);
            quotaBar.GetComponent<UIHealthBar>().setMultiplier(levelObjective.getMoney() / levelObjective.getQuota());
        }
    }

    void UpdateMoney()
    {
        if (levelObjective)
        {
            moneyCount.GetComponent<Text>().text = "$" + Math.Round(levelObjective.getMoney(), 2);
        }
    }

    void UpdateWaveCount()
    {
        if (WaveController.instance)
        {
            waveCount.GetComponent<Text>().text = "WAVE\n" + (WaveController.instance.currentWave + 1) + " out of " + WaveController.instance.waves.Length;
        }
    }
}
