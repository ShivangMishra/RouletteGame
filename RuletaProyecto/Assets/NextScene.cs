using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.Audio;
public class NextScene : MonoBehaviour
{
    public AudioSource audioSource;
    public VideoPlayer video;
    bool changed;
    private void Start()
    {
        DontDestroyOnLoad(audioSource);
    }
    private void Update()
    {
        if (video.isPaused && !changed) { SceneManager.LoadScene(1); changed = true;  }
    }
}
