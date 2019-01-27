using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBlowUp : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem sparks;

    public Transform car;

    public float shrinkSpeed = 0.99f;
	
	public IEnumerator Particles()
    {
        if (!fire.isPlaying)
        {
            fire.gameObject.SetActive(true);
            fire.Play();
        }
        if (!sparks.isPlaying)
        {
            sparks.gameObject.SetActive(true);
            sparks.Play();
        }

        yield return new WaitForSeconds(3.0f);
    }

    public IEnumerator ShrinkCar()
    {
        float size = car.transform.localScale.x;

        while (size > 0.1f)
        {
            size = car.transform.localScale.x;

            car.transform.localScale *= shrinkSpeed;

            Debug.Log(car.transform.localScale);

            yield return null;
        }

        if (fire.isPlaying)
        {
            fire.Stop();
        }
        if (sparks.isPlaying)
        {
            sparks.Stop();
        }
               

        yield return new WaitForSeconds(1.0f);

        Destroy(car.parent.gameObject);
    }
}
