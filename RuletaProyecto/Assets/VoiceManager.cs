using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager instance;
    [SerializeField] AudioSource audioSource;
    public int voice; //0 - Male; 1 - Female
    public AudioClip[] welcomeAudio;
    public AudioClip[] megaWinningsAudio;
    public AudioClip[] youCanWatch;
    public AudioClip[] BeforeWatching;
    public AudioClip[] winnerNumbers;

    public AudioClip[] number0;
    public AudioClip[] number1;
    public AudioClip[] number2;
    public AudioClip[] number3;
    public AudioClip[] number4;
    public AudioClip[] number5;
    public AudioClip[] number6;
    public AudioClip[] number7;
    public AudioClip[] number8;
    public AudioClip[] number9;

    public AudioClip[] congratulations;
    public AudioClip[] nextWinner;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(this.gameObject); }
    }
    public void PlayVoiceManager(AudioClip[] audioClip)
    {
        audioSource.clip = audioClip[voice];
        audioSource.Play();
    }
    public void SetVoice(int i)
    {
        voice = i;
    }
}
