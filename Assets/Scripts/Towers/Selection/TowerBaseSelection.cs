using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseSelection : MonoBehaviour {

    private GameObject UISelectionObject;
    private List<TowerPlace> towerSelections = new List<TowerPlace>();
    private int selectedTowerBase = -1;

    RaycastHit hitObjects;

	// Use this for initialization
	void Start ()
    {
        UISelectionObject = GameObject.FindGameObjectWithTag("Upgrade");
        UISelectionObject.SetActive(false);
        towerSelections.AddRange(FindObjectsOfType<TowerPlace>());	
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
        }
    }



    public void DeSelected()
    {
        selectedTowerBase = -1;
        UISelectionObject.SetActive(false);
    }
}
