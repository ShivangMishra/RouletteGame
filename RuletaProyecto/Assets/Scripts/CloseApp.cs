using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class CloseApp : MonoBehaviour
{
    public VideoPlayer video;
    private void Update()
    {
        if (video.isPaused)
        {
           // Recorder.instance.StopRecording();
            Application.Quit();
        }
    }
}
