using Science;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] waypoints;

    public static bool CanMove { get; set; } = true;
    public static int CurrentWaypoint { get; private set; }
    public static bool InLastWaypoint { get; private set; }
    public static GameObject LastWaypoint { get; private set; }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapSprite;

    private int _passedSteps;
    private bool _isStartPosition;
    private const int RotationRatio = 90;

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
        if (Dice.IsThrows && _passedSteps < Dice.Steps && CanMove)
        {
            InLastWaypoint = false;
            CameraMovement.MoveToPlayer(gameObject, cam, mapSprite);
            
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[CurrentWaypoint].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position != waypoints[CurrentWaypoint].transform.position)
                return;

            if (waypoints[CurrentWaypoint].TryGetComponent(out InfoCell cell))
            {
                CanMove = false;
                CameraMovement.CanMove = false;
                cell.ShowDetails();
            }
                
            gameObject.transform.rotation = SetRotation();
            CurrentWaypoint = (CurrentWaypoint + 1) % waypoints.Length;
            
            if (_isStartPosition)
                _isStartPosition = false;
            else
                _passedSteps++;
        }
        else if (CanMove)
        {
            InLastWaypoint = _passedSteps > 0;
            if (InLastWaypoint)
                LastWaypoint = waypoints[CurrentWaypoint - 1 >= 0 ? CurrentWaypoint - 1 : waypoints.Length - 1];
            
            _passedSteps = 0;
            Dice.IsThrows = false;
        }
    }

    private Quaternion SetRotation()
    {
        var ratio = 0;

        if (waypoints[(CurrentWaypoint + 1) % waypoints.Length].transform.position.x > gameObject.transform.position.x)
            ratio = RotationRatio * 0;
        else if (waypoints[(CurrentWaypoint + 1) % waypoints.Length].transform.position.x <
                 gameObject.transform.position.x)
            ratio = RotationRatio * 2;
        else if (waypoints[(CurrentWaypoint + 1) % waypoints.Length].transform.position.y <
                 gameObject.transform.position.y)
            ratio = RotationRatio * 3;
        else if (waypoints[(CurrentWaypoint + 1) % waypoints.Length].transform.position.y >
                 gameObject.transform.position.y)
            ratio = RotationRatio * 1;

        return Quaternion.AngleAxis(ratio, Vector3.forward);
    }
}
