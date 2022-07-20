using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberSpins=1;
    public static GameManager instance;
    public float speedA=-300, speedB=-300, speedC=-300, speedD=-300;
    public float timeA, timeB, timeC, timeD;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
             }

    }
    public void SetNumberSpins(int i)
    {
        numberSpins = i;
    }
    public void SetSpeedA(float f)
    {
        speedA = f;
    }
    public void SetSpeedB(float f)
    {
        speedB = f;
    }
    public void SetSpeedC(float f)
    {
        speedC = f;
    }
    public void SetSpeedD(float f)
    {
        speedD = f;
    }

    public void SetTimeA(float f)
    {
        timeA = f;
    }
    public void SetTimeB(float f)
    {
        timeB = f;
    }
    public void SetTimeC(float f)
    {
        timeC = f;
    }
    public void SetTimeD(float f)
    {
        timeD = f;
    }
}
