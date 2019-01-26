using UnityEngine;
using System.Collections;

//Place this on any object to make it move across the level as an enemy
public class Movement : MonoBehaviour
{
    private MovementController movementController;
    private Rigidbody rb;
    private Enemy enemy;

    public Vector3 moveToPoint;
    public Vector3 offsetToPoint;
    public Vector3 directionToPoint;
    public int currentPointIndex;

    public float maxSpeed = 8.0f;
    public float acceleration = 8.0f;

    public float distanceFromPointCheck; //How close to the next point before going to next position
    private float rotationSpeed; //The speed the unit rotates to head towards the point;
    public bool canMove;

    private void Start()
    {
        movementController = GameObject.FindGameObjectWithTag("MasterPositions").GetComponent<MovementController>();
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<Enemy>();
        rotationSpeed = enemy.GetMoveSpeed() / 2;

        moveToPoint = movementController.masterPositions[currentPointIndex].position;
    }

    void FixedUpdate()
    {
        Move();
    }

    void CheckNextPoint()
    {
        if (!gameObject.activeInHierarchy)
            return;

        currentPointIndex++;
        
        if (currentPointIndex >= movementController.masterPositions.Count)
        {
            TempRemoveUnit();
            return;
        }
        else
        {
            moveToPoint = movementController.masterPositions[currentPointIndex].position;
            offsetToPoint = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
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

            if (rb.velocity.magnitude <= maxSpeed)
            {
                rb.AddRelativeForce(new Vector3(0, 0, acceleration));
            }

            //Vector3.ClampMagnitude(rb.velocity, 10);

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

        WaveController.instance.activeUnits.Remove(gameObject);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
