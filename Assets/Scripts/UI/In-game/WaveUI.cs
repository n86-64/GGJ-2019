using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    private WaveController waveController;

	// Use this for initialization
	void Start ()
    {
        waveController = FindObjectOfType<WaveController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waveController)
        {
            GetComponent<Text>().text = "Wave: " + (waveController.currentWave + 1) + "/" + waveController.waves.Length;
        }
	}
}
