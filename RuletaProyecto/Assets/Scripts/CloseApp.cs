using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Evereal.VideoCapture;
public class CloseApp : MonoBehaviour
{

    public VideoPlayer video;
    bool stopped = false;
    VideoCapture vc;
    private void Update()
    {
        if (stopped)
        {
            // if (vc.status == CaptureStatus.READY)
            // {
            //     Application.Quit();
            // }
            return;
        }
        if (video.isPaused)
        {
            if (vc == null)
            {
                vc = GameObject.Find("VideoCapture").GetComponent<VideoCapture>();
            }
            stopped = true;
            Debug.Log("STOP CAPTURE");
            vc.StopCapture();
            // Recorder.instance.StopRecording();
            // Application.Quit();
        }
    }
}
