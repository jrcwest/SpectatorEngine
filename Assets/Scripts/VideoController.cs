using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    private float speed = 0.5f;
    public GameObject videoSurface;
    UnityEngine.Video.VideoPlayer videoPlayer;

    Camera mainCamera;
    

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
