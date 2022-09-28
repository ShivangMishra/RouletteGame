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
        Screen.SetResolution(vc.frameWidth, vc.frameHeight, false);
        Debug.LogWarning(vc.frameWidth + " , " + vc.frameHeight);
        vc.quitAfterCapture = true;
    }
}
