using UnityEngine;
using System.Collections;

//Place this on any object to make it move across the level as an enemy
public class PathMovement : MonoBehaviour
{
    public MovementController movementController;


    public Vector3 moveToPoint;
    public Vector3 offsetToPoint;
    public Vector3 directionToPoint;
    public int currentPointIndex;

    public float distanceFromPointCheck; //How close to the next point before going to next position
    public float tempSpeed; //This will be replaced by Enemy Speed;
    public float rotationSpeed; //The speed the unit rotates to head towards the point;
    public bool canMove;

    private void Start()
    {
        movementController = FindObjectOfType<MovementController>();

        moveToPoint = movementController.masterPositions[currentPointIndex].position;
    }

    void Update()
    {
        Move();
    }

    void CheckNextPoint()
    {
        currentPointIndex++;


        if (currentPointIndex > movementController.masterPositions.Count)
        {

            TempRemoveUnit();
            return;
        }
        else
        {
            moveToPoint = movementController.masterPositions[currentPointIndex].position;
            Vector3 offsetPoint = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

        }
    }

    void RotateTowardsPoint()
    {
        Vector3 lookAtGoal = new Vector3(moveToPoint.x, transform.position.y, moveToPoint.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToPoint), Time.deltaTime * rotationSpeed);
    }

    void Move()
    {
        if (canMove)
        {
            directionToPoint = (moveToPoint + offsetToPoint) - transform.position;
            transform.Translate(transform.forward * tempSpeed * Time.deltaTime, Space.World);
            RotateTowardsPoint();

            if (Vector3.Distance(transform.position, moveToPoint) <= distanceFromPointCheck)
            {
                CheckNextPoint();
            }
        }
    }

    //This would remove the enemy and do something like add point. To be replaced by a different system.
    void TempRemoveUnit()
    {
        //Add points
        print("Enemy should die");
        transform.gameObject.SetActive(false);
    }

}
