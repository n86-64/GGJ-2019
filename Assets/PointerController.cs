using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public List<GameObject> arrows;

    public float loopTime = 4.0f;
    public float speed = 1.0f;
    private float timeElapsed = 0.0f;

	void Update ()
    {
		if (timeElapsed >= loopTime)
        {
            timeElapsed = 0.0f;

            foreach (GameObject arrow in arrows)
            {
                arrow.SetActive(false);
            }
        }
        else
        {
            timeElapsed += Time.deltaTime * speed;
        }

        if (timeElapsed > 1.0f)
        {
            arrows[0].SetActive(true);
        }

        if (timeElapsed > 2.0f)
        {
            arrows[1].SetActive(true);
        }

        if (timeElapsed > 3.0f)
        {
            arrows[2].SetActive(true);
        }
    }
}
