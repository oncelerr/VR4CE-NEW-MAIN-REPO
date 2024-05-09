using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Play video at specific time (e.g., 30 seconds)
        videoPlayer.time = 188.95f;
        videoPlayer.Play();
    }
}
