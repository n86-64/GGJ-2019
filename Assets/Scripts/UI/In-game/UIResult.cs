using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    
	void Awake ()
    {
        if (WaveController.instance)
        {
            GetComponent<Text>().text = "YOU LASTED\n" + (WaveController.instance.currentWave) + " WAVES";
        }
    }
	
}
