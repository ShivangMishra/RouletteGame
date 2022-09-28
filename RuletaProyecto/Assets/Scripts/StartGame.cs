using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Evereal.VideoCapture;
using TMPro;
public class StartGame : MonoBehaviour
{
    [SerializeField]
    TMP_InputField statusField;
    public void StartButton()
    {
        int num = GameManager.instance.checkNumbers();
        if (num != -1)
        {
            statusField.text = "Invalid number input for Round : " + num;
            return;
        }
        statusField.text = "Generating!";
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
