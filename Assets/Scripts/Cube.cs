using UnityEngine;

public class Cube : MonoBehaviour 
{ 
    public static bool IsCubeThrows { get; set; }

    public static int Steps { get; private set; }
    
    public void ThrowCube()
    {
        Steps = GetCubeValue();
        Debug.Log($"Number: {Steps}");
        IsCubeThrows = true;
    }
    
    private static int GetCubeValue() => Random.Range(1, 6);
}
