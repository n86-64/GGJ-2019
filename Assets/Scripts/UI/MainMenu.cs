using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private int menuSelection = 0;

    public List<Button> menuButtons;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuSelection++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuSelection--;
        }
        Wrap();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            menuButtons[menuSelection].onClick.Invoke();
        }
    }


    void Wrap()
    {
        if (menuSelection == menuButtons.Count ) { menuSelection = 0; }
        else if(menuSelection < 0) { menuSelection = menuButtons.Count - 1; }
    }

}
