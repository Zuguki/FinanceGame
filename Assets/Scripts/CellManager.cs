using DefaultNamespace;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private void Update()
    {
        ShowCellDetails();
    }

    private void ShowCellDetails()
    {
        if (!PlayerMove.InLastWaypoint)
            return;
        
        var cell = PlayerMove.LastWaypoint.GetComponent<ICell>();
        cell.ShowDetails();
    }
}
