using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static bool CanMove = true;
    
    [SerializeField] private Camera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;

    [SerializeField] private SpriteRenderer mapRenderer;

    private Vector3 _cameraDragOrigin;

    private const float MapDelta = 2f;
    
    public static void MoveToPlayer(GameObject player, Camera camera, SpriteRenderer mapRenderer)
    {
        var playerPosition = player.transform.position;
        var cameraPosition = camera.transform.position;
        var difference = playerPosition - cameraPosition;
        
        var resultPoint = 
            new Vector3(cameraPosition.x + difference.x, cameraPosition.y + difference.y, cameraPosition.z);
        cameraPosition = ClampCamera(resultPoint, camera, mapRenderer);
        camera.transform.position = cameraPosition;
    }

    private void Update()
    {
        if (!CanMove)
            return;
        
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

        cam.transform.position = ClampCamera(cam.transform.position, cam, mapRenderer);
    }

    private void ZoomIn()
    {
        var newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        cam.transform.position = ClampCamera(cam.transform.position, cam, mapRenderer);
    }

    private static Vector3 ClampCamera(Vector3 targetPosition, Camera camera, Renderer mapRenderer)
    {
        var mapPosition = mapRenderer.transform.position;
        var bounds = mapRenderer.bounds;
        
        var orthographicSize = camera.orthographicSize;
        var cameraWidth = orthographicSize * camera.aspect;

        var (mapMinX, mapMaxX, mapMinY, mapMaxY) = GetBounds(mapPosition, bounds);

        var minX = mapMinX + cameraWidth;
        var maxX = mapMaxX - cameraWidth;

        var minY = mapMinY + orthographicSize;
        var maxY = mapMaxY - orthographicSize;

        var newXPosition = Mathf.Clamp(targetPosition.x, minX, maxX);
        var newYPosition = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newXPosition, newYPosition, targetPosition.z);
    }

    private static (float, float, float, float) GetBounds(Vector3 mapPosition, Bounds bounds) => 
        (mapPosition.x - bounds.size.x / MapDelta, mapPosition.x + bounds.size.x / MapDelta,
            mapPosition.y - bounds.size.y / MapDelta, mapPosition.y + bounds.size.y / MapDelta);

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            _cameraDragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if (!Input.GetMouseButton(0))
            return;

        var difference = _cameraDragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
        cam.transform.position = ClampCamera(cam.transform.position + difference, cam, mapRenderer);
    }


}
