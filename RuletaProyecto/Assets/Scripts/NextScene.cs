using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEditor;

public class NextScene : MonoBehaviour
{
    public VideoPlayer video;
    bool changed;
  
    private void Update()
    {
        if (video.isPaused && !changed) { SceneManager.LoadScene(1); changed = true;  }
    }
}
