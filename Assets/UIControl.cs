using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject inGameDisplay;

    private bool paused;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            SwitchDisplays();
        }
	}

    void SwitchDisplays()
    {
        pauseMenu.SetActive(paused);
        inGameDisplay.SetActive(!paused);
    }


    public void GoToLevel(string name)
    {
        SceneManager.LoadScene(name); 
    }
}
