using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public Camera cam;
    private Vector3 camOrigin;
    // public float maxZoom = 5;
    // public float minZoom = 0;
    //public float sensitivity = 0.5f;
    //public float speed = 30;
    //float targetZoom;
    //void Start()
    //{
    //    targetZoom = cam.orthographicSize;
    //}
    //void Update()
    //{
    //    if (Input.mouseScrollDelta.y == 0)
    //        return;

    //    targetZoom = cam.orthographicSize - (Input.mouseScrollDelta.y) * speed * (Time.deltaTime);
    //    cam.orthographicSize = Mathf.Clamp(targetZoom, minZoom, maxZoom);
    //}

    private void Start()
    {
        camOrigin = cam.transform.position;
    }

    // private void Update()
    // {
    //     // Scroll forward
    //     if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //     {
    //         ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
    //     }

    //     // Scoll back
    //     if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //     {
    //         ZoomOrthoCamera(camOrigin, -1);
    //     }

    // }

    // void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
    // {
    //     // Calculate how much we will have to move towards the zoomTowards position
    //     float multiplier = (1.0f / cam.orthographicSize * amount);

    //     // Move camera
    //     transform.position += (zoomTowards - transform.position) * multiplier;
        

    //     // Zoom camera
    //     cam.orthographicSize -= amount;

    //     // Limit zoom
    //     cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    // }

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
