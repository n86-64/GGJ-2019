using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseSelection : MonoBehaviour
{

    private GameObject UISelectionObject;
    private List<TowerPlace> towerSelections = new List<TowerPlace>();
    private int selectedTowerBase = -1;

    // dont know why this is never used but its one of them i added a redundant line below to clear a console warning
    private bool exitSelection = false;

    RaycastHit hitObjects;

	// Use this for initialization
	void Start ()
    {
        UISelectionObject = GameObject.FindGameObjectWithTag("Upgrade");
        UISelectionObject.SetActive(false);
        towerSelections.AddRange(FindObjectsOfType<TowerPlace>());	

        // heres that thing i was on about above ---^
        if (exitSelection)
        {
            // do something
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectTower();
        }
	}


    void selectTower()
    {
        // Generate a raycast
        Vector3 screenPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition) * new Vector2(1920.0f, 1080.0f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitObjects, 1000.0f);

        if (hitObjects.collider)
        {
            // Hit an object. Select it.
            if (selectedTowerBase == -1 &&
                towerSelections.Contains(hitObjects.collider.gameObject.GetComponent<TowerPlace>()))
            {
                selectedTowerBase = towerSelections.IndexOf(hitObjects.collider.gameObject.GetComponent<TowerPlace>());
                Debug.Log("TowerSelected: " + towerSelections[selectedTowerBase].gameObject.name);
                UISelectionObject.GetComponent<RectTransform>().anchoredPosition = screenPoint;
                UISelectionObject.SetActive(true);
            }
            //else
            //{
            //    selectedTowerBase = -1;
            //    UISelectionObject.SetActive(false);
            //}
        }

    }

    public TowerPlace getSelectedTowerPlace()
    {
        if(selectedTowerBase >= 0)
        {
            return towerSelections[selectedTowerBase];
        }

        return null;
    }

    public void DeSelected()
    {
        selectedTowerBase = -1;
        UISelectionObject.SetActive(false);
    }
}
