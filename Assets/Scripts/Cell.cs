using DefaultNamespace;
using UnityEngine;

public class Cell : MonoBehaviour, ICell
{
    public CellOptions cellOption;
    
    public void ShowDetails() => Debug.Log(cellOption);
}
