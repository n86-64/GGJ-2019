using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement
    private Rigidbody rb;
    Vector3 velocity;

    // stamina
    public float walkingSpeed = 10.0f;
    public float runningSpeed = 20.0f;
    
    private float moveSpeed = 0.0f;
    public float rotationSpeed = 0.0f;

    private void Start ()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.None;
	}
	
	private void Update ()
    {
        // lock cursor
        if (Input.GetKeyDown("l"))
        {
            if (Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        if (moveSpeed != walkingSpeed)
        {
            moveSpeed = walkingSpeed;
        }

        MovePlayer();
    }

    private void MovePlayer()
    {
        velocity = new Vector3(0, rb.velocity.y, 0);

        // if moving forward
        if (Input.GetKey("w"))
        {
            velocity += new Vector3((transform.forward.x * moveSpeed) + (transform.right.x * moveSpeed), 0, (transform.forward.z * moveSpeed) + (transform.right.z * moveSpeed));
        }

        // if moving backwards
        if (Input.GetKey("s"))
        {
            velocity += new Vector3(-((transform.forward.x * moveSpeed) + (transform.right.x * moveSpeed)), 0, -((transform.forward.z * moveSpeed) + (transform.right.z * moveSpeed)));
        }

        // if moving left
        if (Input.GetKey("a"))
        {
            velocity += new Vector3(-((transform.forward.x * moveSpeed) + (transform.right.x * moveSpeed)), 0, (transform.forward.z * moveSpeed) + (transform.right.z * moveSpeed));
        }

        // if moving right
        if (Input.GetKey("d"))
        {
            velocity += new Vector3((transform.forward.x * moveSpeed) + (transform.right.x * moveSpeed), 0, -((transform.forward.z * moveSpeed) + (transform.right.z * moveSpeed)));
        }

        rb.velocity = velocity;
    }
}
