using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Evereal.VideoCapture;
public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);

        VideoCapture vc = GameObject.Find("VideoCapture")
        .GetComponent<VideoCapture>();
        // vc.resolutionPreset = Evereal.VideoCapture.ResolutionPreset.CUSTOM;
        // ResolutionManager rm = GameObject.Find("ResolutionManager").GetComponent<ResolutionManager>();
        // vc.frameWidth = rm.getWidth();
        // vc.frameHeight = rm.getHeight();
        // vc.saveFolder = path;
        Screen.SetResolution(vc.frameWidth, vc.frameHeight, false);
        vc.quitAfterCapture = true;
        vc.StartCapture();
    }
}
