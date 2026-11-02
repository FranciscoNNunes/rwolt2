using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    public Vector3 targetPosition;
    void Start()
    {
        targetPosition = pointB.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {

            targetPosition = (targetPosition == pointB.position) ? pointA.position : pointB.position;
        }
    }
}
