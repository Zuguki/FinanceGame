using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{ 
    public bool IsCubeThrows { get; set; }
    
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cam;
    [SerializeField] private SpriteRenderer mapSprite;

    public void ThrowCube()
    {
        var steps = GetCubeValue();
        Debug.Log($"Number: {steps}");
        IsCubeThrows = true;
    }

    private void Start()
    {
        CameraMovement.MoveToPlayer(player, cam, mapSprite);
    }
    
    private static int GetCubeValue() => Random.Range(1, 6);
}
