using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour {

    [SerializeField]
    private float multiplier = 0.1f;

    public Image bar;
    public float barLength = 100.0f;

    private void Start()
    {
        barLength = bar.rectTransform.rect.width;
    }

    public void setMultiplier(float newMultiplier)
    {
        multiplier = newMultiplier;
    }
	
	void Update ()
    {
        multiplier = Mathf.Clamp(multiplier, 0.0f, 1.0f);
        bar.rectTransform.sizeDelta = new Vector2(barLength * multiplier, bar.rectTransform.rect.height);
	}
}
