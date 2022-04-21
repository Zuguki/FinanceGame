using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector] public int currentWaypoint;
    
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapSprite;

    private int _passedSteps;

    private void Start()
    {
        transform.position = waypoints[currentWaypoint].transform.position;
        CameraMovement.MoveToPlayer(gameObject, cam, mapSprite);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Cube.IsCubeThrows && _passedSteps < Cube.Steps)
        {
            CameraMovement.MoveToPlayer(gameObject, cam, mapSprite);
            
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[currentWaypoint].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position != waypoints[currentWaypoint].transform.position)
                return;
            
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            _passedSteps++;
        }
        else
        {
            _passedSteps = 0;
            Cube.IsCubeThrows = false;
        }
    }
}
