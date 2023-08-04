using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    private float speed = 0.5f;
    Camera mainCamera;
    UnityEngine.Video.VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        videoPlayer = mainCamera.GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rewind();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FastForward();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
    }    

    public void Rewind()
    {
        videoPlayer.time -= speed;
    }
    public void FastForward()
    {
        videoPlayer.time += speed;
    }
    public void Pause()
    {
        if (!videoPlayer.isPaused)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
