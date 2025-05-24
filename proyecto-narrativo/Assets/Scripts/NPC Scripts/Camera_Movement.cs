using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] 
    private Camera cam;
    private Vector3 dragOrigin;

    [Header("Zoom Settings")]
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 20f;

    private void Update()
    {
        PanCamera();
        ZoomCamera();
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            Vector3 diference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += diference;
        }
    }

    private void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
