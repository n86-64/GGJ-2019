using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        WaveController waveController = FindObjectOfType<WaveController>();
        if (waveController)
        {
            GetComponent<Text>().text = "You Lasted: " + (waveController.currentWave) + " waves.";
        }
    }
	
}
