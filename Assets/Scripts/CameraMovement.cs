using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    private Vector3 _dragOrigin;

    private void Update()
    {
        PanCamera();
        Zoom();
    }

    private void Zoom()
    {
        switch (Input.mouseScrollDelta.y)
        {
            case > 0:
                ZoomIn();
                break;
            case < 0:
                ZoomOut();
                break;
        }
    }

    private void ZoomOut()
    {
        var newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    private void ZoomIn()
    {
        var newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            _dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!Input.GetMouseButton(0))
            return;

        var difference = _dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
        cam.transform.position += difference;
    }
}
