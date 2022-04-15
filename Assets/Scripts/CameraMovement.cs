using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    [SerializeField] private SpriteRenderer mapRenderer;

    private Vector3 _dragOrigin;

    private float _mapMinX, _mapMaxX ,_mapMinY, _mapMaxY;
    private const float MapDelta = 2f;

    private void Awake()
    {
        var mapPosition = mapRenderer.transform.position;
        var bounds = mapRenderer.bounds;

        _mapMinX = mapPosition.x - bounds.size.x / MapDelta;
        _mapMaxX = mapPosition.x + bounds.size.x / MapDelta;

        _mapMinY = mapPosition.y - bounds.size.y / MapDelta;
        _mapMaxY = mapPosition.y + bounds.size.y / MapDelta;
    }

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

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private void ZoomIn()
    {
        var newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        var orthographicSize = cam.orthographicSize;

        var cameraWidth = orthographicSize * cam.aspect;

        var minX = _mapMinX + cameraWidth;
        var maxX = _mapMaxX - cameraWidth;

        var minY = _mapMinY + orthographicSize;
        var maxY = _mapMaxY - orthographicSize;

        var newXPosition = Mathf.Clamp(targetPosition.x, minX, maxX);
        var newYPosition = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newXPosition, newYPosition, targetPosition.z);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            _dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!Input.GetMouseButton(0))
            return;

        var difference = _dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
        cam.transform.position = ClampCamera(cam.transform.position + difference);
    }
}
