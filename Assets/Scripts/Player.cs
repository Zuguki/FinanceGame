using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public List<GameObject> waypoints;
    
    [HideInInspector] public int currentWaypoint;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapSprite;

    public void ThrowCube()
    {
        var steps = GetCubeValue();
        Debug.Log($"Number: {steps}");
        MovePlayer(steps);
    }

    private void Start()
    {
        CameraMovement.MoveToPlayer(player, cam, mapSprite);
    }
    
    private static int GetCubeValue() => Random.Range(1, 6);

    private int GetNextIndex() => currentWaypoint + 1 & waypoints.Count;
    
    private void MovePlayer(int steps)
    {
        CameraMovement.MoveToPlayer(player, cam, mapSprite);
        currentWaypoint = GetNextIndex();
        player.transform.position = Vector3.MoveTowards(
            player.transform.position,
            waypoints[currentWaypoint].transform.position,
            moveSpeed * Time.deltaTime);
    }
}
