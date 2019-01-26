using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera cam;
    public Transform objToFollow;
    public float speed = 1;

    public float zoomSpeed = 1;
    private Vector3 startPos;

    public bool scrollToZoom = false;

    private void LateUpdate()
    {
        float camZoom = cam.orthographicSize;
        if (scrollToZoom)
        {
            camZoom -= Input.GetAxis("Mouse ScrollWheel") * 5;
            Debug.Log("cam zoom " + camZoom);
            cam.orthographicSize = Mathf.Clamp(camZoom, 3, 30);
        }

        if (Vector3.Distance(transform.position, objToFollow.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(
                transform.position, objToFollow.position,
                Time.deltaTime * speed);

            
            if (!scrollToZoom)
            {
                if (Vector3.Distance(startPos, transform.position) <
                    Vector3.Distance(transform.position, objToFollow.position))
                {
                    camZoom += Time.deltaTime * zoomSpeed;
                }
                else
                {
                    camZoom -= Time.deltaTime * zoomSpeed;
                }
            }
            
            cam.orthographicSize = Mathf.Clamp(camZoom, 3, 30);
        }
        else
        {
            startPos = transform.position;
        }
    }
}
