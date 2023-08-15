using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    private float speed = 2f;
    public GameObject videoSurface;
    UnityEngine.Video.VideoPlayer videoPlayer;

    Camera mainCamera;

    private IEnumerator rewindCoroutine;
    private IEnumerator fastforwardCoroutine;

    private int frames = 0;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //ResizeSpriteToScreen();
        videoPlayer = videoSurface.GetComponentInParent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        // Slow down the tracking to every 10 frames?
        if (frames % 10 == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Rewind();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                FastForward();
            }
        }            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            videoPlayer.playbackSpeed = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            videoPlayer.playbackSpeed = 1;
        }
    }    

    public void Rewind()
    {
        if (!videoPlayer.isPaused)
        {
            Pause();
            videoPlayer.time -= speed;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                videoPlayer.time -= speed;
            }
        }        
    }
    public void FastForward()
    {
        if (!videoPlayer.isPaused)
        {
            Pause();
            videoPlayer.time += speed;
        }
        else
        {
            videoPlayer.time += speed;
        }        
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

    //public void ResizeSpriteToScreen() {
    //    // Angle the camera can see above the center.
    //    float halfFovRadians = GetComponent<Camera>().fieldOfView * Mathf.Deg2Rad / 2f;

    //    // How high is it from top to bottom of the view frustum,
    //    // in world space units, at our target depth?
    //    float visibleHeightAtDepth = depth * Mathf.Tan(halfFovRadians) * 2f;

    //    // You could also use Sprite.bounds for this.
    //    float spriteHeight = spriteRenderer.sprite.rect.height
    //                       / spriteRenderer.sprite.pixelsPerUnit;

    //    // How many times bigger (or smaller) is the height we want to fill?
    //    float scaleFactor = visibleHeightAtDepth / spriteHeight;

    //    // Scale to fit, uniformly on all axes.
    //    spriteRenderer.transform.localScale = Vector3.one * scaleFactor;
    //}
}
