using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera cam;
    public Transform objToFollow;
    public float speed = 1;

    private float distance = 3;
    private Vector3 startPos;

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, objToFollow.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(
                transform.position, objToFollow.position,
                Time.deltaTime * speed);

            //float t = Mathf.InverseLerp(
            //    startPos.magnitude, objToFollow.position.magnitude,
            //    transform.position.magnitude);
            //t = Mathf.SmoothStep(0, 1, t);
            //cam.orthographicSize = Mathf.Lerp(5, 3, Time.deltaTime * speed);
        }
        else
        {
            startPos = transform.position;
            //cam.orthographicSize = Mathf.Lerp(3, 5, Time.deltaTime * speed);
        }

        
        //Debug.Log(distance * Mathf.Sin(Time.deltaTime * speed));

        //distance *= Mathf.Sin(Time.deltaTime * speed);//3 + (Vector3.Distance(transform.position, objToFollow.position) / 2);
        
    }
}
