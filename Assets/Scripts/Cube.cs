using UnityEngine;

public class Cube : MonoBehaviour 
{ 
    public static bool IsThrows { get; set; }

    public static int Steps { get; private set; }
    
    public void Throw()
    {
        Steps = GetCubeValue();
        Debug.Log($"Number: {Steps}");
        IsThrows = true;
    }
    
    private static int GetCubeValue() => Random.Range(1, 6);
}
