using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public Camera cam;
    private Vector3 camOrigin;

    private void Start()
    {
        camOrigin = cam.transform.position;
    }

    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed = 20f;
    [SerializeField] private float minCamSize = 0.1f;
    [SerializeField] private float maxCamSize = 5f;
    private Vector3 targetPos;

    private void Update()
    {
        Zoom();
    }
    
    private void Zoom()
    {
        // Get MouseWheel-Value and calculate new Orthographic-Size
        // (while using Zoom-Speed-Multiplier)
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        float newZoomLevel = cam.orthographicSize - mouseScrollWheel;

        // Get Position before and after zooming
        Vector3 mouseOnWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        cam.orthographicSize = Mathf.Clamp(newZoomLevel, minCamSize, maxCamSize);
        Vector3 mouseOnWorld1 = cam.ScreenToWorldPoint(Input.mousePosition);

        // Calculate Difference between Positions before and after Zooming
        Vector3 posDiff = mouseOnWorld - mouseOnWorld1;

        // Add Difference to Camera Position
        Vector3 camPos = cam.transform.position;

        targetPos = new Vector3(
            camPos.x + posDiff.x,
            camPos.y + posDiff.y,
            camPos.z);

        // Apply Target-Position to Camera
        cam.transform.position = targetPos;

        if (cam.orthographicSize == maxCamSize)
        {
            cam.transform.position = camOrigin;
        }
    }
}
