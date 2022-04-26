using DefaultNamespace;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] waypoints;

    public static int CurrentWaypoint { get; private set; }
    public static bool InLastWaypoint { get; private set; }
    public static GameObject LastWaypoint { get; private set; }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapSprite;

    private int _passedSteps;
    private bool _isStartPosition;

    private void Start()
    {
        transform.position = waypoints[CurrentWaypoint].transform.position;
        CameraMovement.MoveToPlayer(gameObject, cam, mapSprite);
        _isStartPosition = true;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Cube.IsThrows && _passedSteps < Cube.Steps)
        {
            InLastWaypoint = false;
            CameraMovement.MoveToPlayer(gameObject, cam, mapSprite);
            
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[CurrentWaypoint].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position != waypoints[CurrentWaypoint].transform.position)
                return;
            
            CurrentWaypoint = (CurrentWaypoint + 1) % waypoints.Length;
            
            if (_isStartPosition)
                _isStartPosition = false;
            else
                _passedSteps++;
        }
        else
        {
            InLastWaypoint = _passedSteps > 0;
            if (InLastWaypoint)
                LastWaypoint = waypoints[CurrentWaypoint - 1];
            
            _passedSteps = 0;
            Cube.IsThrows = false;
        }
    }
}
