using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameState : MonoBehaviour
{
    private ObjectiveData levelObjective;

    // properties
    public GameObject quotaUI;
    public GameObject quotaBarUI;
    public GameObject moneyUI;
    public GameObject waveUI;

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
            float money = levelObjective.getMoney(); 
            float quota = levelObjective.getQuota();
            if(money < quota) { quotaUI.GetComponent<Text>().color = Color.red; }
            else { quotaUI.GetComponent<Text>().color = Color.green;  }

            quotaUI.GetComponent<Text>().text = "REQUIRED: $" + Math.Round(levelObjective.getQuota(), 2);
            quotaBarUI.GetComponent<UIHealthBar>().setMultiplier(levelObjective.getMoney() / levelObjective.getQuota());
        }
    }

    void UpdateMoney()
    {
        if (levelObjective)
        {
            moneyUI.GetComponent<Text>().text = "MONEY: $" + Math.Round(levelObjective.getMoney(), 2);
        }
    }

    void UpdateWaveCount()
    {
        if (WaveController.instance)
        {
            waveUI.GetComponent<Text>().text = "WAVE\n" + (WaveController.instance.currentWave + 1) + " out of " + WaveController.instance.waves.Length;
        }
    }
}
