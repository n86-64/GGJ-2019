using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera cam;
    public Transform objToFollow;
    public float speed = 1;

    private float distance = 3;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, objToFollow.position,
            Time.deltaTime * speed);
        
        distance = 3 + (Vector3.Distance(transform.position, objToFollow.position) / 2);
        cam.orthographicSize = distance;
    }
}
