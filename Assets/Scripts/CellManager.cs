using DefaultNamespace;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private void Update()
    {
        if (PlayerMove.InLastWaypoint)
            ShowCellDetails();
    }

    private static void ShowCellDetails()
    {
        PlayerMove.LastWaypoint.GetComponent<ICell>().ShowDetails();
    }
}
