using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorVoice : MonoBehaviour
{
    public float seconds;
    public AudioClip[] audioClip;
    void Start()
    {
        Invoke("Play", seconds);
    }
    public void Play()
    {
        VoiceManager.instance.PlayVoiceManager(audioClip);
    }

}
