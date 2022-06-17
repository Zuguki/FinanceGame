using Main;
using Science;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    private void Update()
    {
        if (PlayerMove.InLastWaypoint && !PlayerMove.LastWaypoint.TryGetComponent(out InfoCell _))
            ShowCellDetails();
    }

    private static void ShowCellDetails()
    {
        CameraMovement.CanMove = false;
        PlayerMove.LastWaypoint.GetComponent<ICell>().ShowDetails();
    }
}
