using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberSpins=1;
    public static GameManager instance;
    public float speedA=-300, speedB=-300, speedC=-300, speedD=-300;
    public float speed2A = -300, speed2B = -300, speed2C = -300, speed2D = -300;
    public float speed3A = -300, speed3B = -300, speed3C = -300, speed3D = -300;
    public float speed4A = -300, speed4B = -300, speed4C = -300, speed4D = -300;
    public float timeA, timeB, timeC, timeD;
    public float time2A, time2B, time2C, time2D;
    public float time3A, time3B, time3C, time3D;
    public float time4A, time4B, time4C, time4D;
    public GameObject[] buttonsCustomize;
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
        switch (i)
        { //CAN CODE BETTER
            case 0:
                buttonsCustomize[0].SetActive(true);
                buttonsCustomize[1].SetActive(false);
                buttonsCustomize[2].SetActive(false);
                buttonsCustomize[3].SetActive(false);
                break;

            case 1:
                buttonsCustomize[0].SetActive(true);
                buttonsCustomize[1].SetActive(true);
                buttonsCustomize[2].SetActive(false);
                buttonsCustomize[3].SetActive(false);
                break;

            case 2:
                buttonsCustomize[0].SetActive(true);
                buttonsCustomize[1].SetActive(true);
                buttonsCustomize[2].SetActive(true);
                buttonsCustomize[3].SetActive(false);
                break;
            case 3:
                buttonsCustomize[0].SetActive(true);
                buttonsCustomize[1].SetActive(true);
                buttonsCustomize[2].SetActive(true);
                buttonsCustomize[3].SetActive(true);
                break;
        }
    }
    #region 1st WinningNumber
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
    #endregion
    #region 2nd WinningNumber
    public void SetSpeed2A(float f)
    {
        speed2A = f;
    }
    public void SetSpeed2B(float f)
    {
        speed2B = f;
    }
    public void SetSpeed2C(float f)
    {
        speed2C = f;
    }
    public void SetSpeed2D(float f)
    {
        speed2D = f;
    }

    public void SetTime2A(float f)
    {
        time2A = f;
    }
    public void SetTime2B(float f)
    {
        time2B = f;
    }
    public void SetTime2C(float f)
    {
        time2C = f;
    }
    public void SetTime2D(float f)
    {
        time2D = f;
    }
    #endregion
    #region 3rd WinningNumber
    public void SetSpeed3A(float f)
    {
        speed3A = f;
    }
    public void SetSpeed3B(float f)
    {
        speed3B = f;
    }
    public void SetSpeed3C(float f)
    {
        speed3C = f;
    }
    public void SetSpeed3D(float f)
    {
        speed3D = f;
    }

    public void SetTime3A(float f)
    {
        time3A = f;
    }
    public void SetTime3B(float f)
    {
        time3B = f;
    }
    public void SetTime3C(float f)
    {
        time3C = f;
    }
    public void SetTime3D(float f)
    {
        time3D = f;
    }
    #endregion
    #region 4th WinningNumber
    public void SetSpeed4A(float f)
    {
        speed4A = f;
    }
    public void SetSpeed4B(float f)
    {
        speed4B = f;
    }
    public void SetSpeed4C(float f)
    {
        speed4C = f;
    }
    public void SetSpeed4D(float f)
    {
        speed4D = f;
    }

    public void SetTime4A(float f)
    {
        time4A = f;
    }
    public void SetTime4B(float f)
    {
        time4B = f;
    }
    public void SetTime4C(float f)
    {
        time4C = f;
    }
    public void SetTime4D(float f)
    {
        time4D = f;
    }
    #endregion
}
