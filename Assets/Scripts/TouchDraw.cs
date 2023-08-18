using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{
    Coroutine drawing;

    [SerializeField] private Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
        if (Input.GetMouseButtonUp(1))
        {
            FinishLine();
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Line 1");
            foreach (GameObject obj in allObjects)
            {
                Destroy(obj);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Line 1");
            foreach (GameObject obj in allObjects)
            {
                LineRenderer line = obj.GetComponent<LineRenderer>();
                line.SetWidth(cam.orthographicSize / 50, cam.orthographicSize / 50);
            }
        }
        
    }

    void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    void FinishLine()
    {
        StopCoroutine(drawing);
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(Resources.Load("Line1") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while(true)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            line.SetWidth(cam.orthographicSize / 50, cam.orthographicSize / 50);
            Debug.Log(cam.orthographicSize);
            // This apparently allows the coroutine to only run once per frame, waiting for the next frame to run again?
            yield return null;
        }
    }
}
