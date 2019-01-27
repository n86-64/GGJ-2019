using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameState : MonoBehaviour {

    private WaveController waveController;
    private Objective levelObjective;

    // properties
    public GameObject quotaCount;
    public GameObject quotaBar;
    public GameObject moneyCount;
    public GameObject waveCount;

    // Use this for initialization
    void Start()
    {
        waveController = FindObjectOfType<WaveController>();
        levelObjective = FindObjectOfType<Objective>();
    }

    // Update is called once per frame
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
            quotaCount.GetComponent<Text>().text = "Quota: £" + Math.Round(levelObjective.getQuota(), 2);
            quotaBar.GetComponent<UIHealthBar>().setMultiplier(levelObjective.getMoney() / levelObjective.getQuota());
        }
    }

    void UpdateMoney()
    {
        if (levelObjective)
        {
            moneyCount.GetComponent<Text>().text = "Money: £" + Math.Round(levelObjective.getMoney(), 2);
        }
    }

    void UpdateWaveCount()
    {
        if (waveController)
        {
            waveCount.GetComponent<Text>().text = "Wave: " + (waveController.currentWave + 1) + "/" + waveController.waves.Length;
        }
    }
}
