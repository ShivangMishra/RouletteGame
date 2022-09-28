using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberSpins = 1;
    public static GameManager instance;
    public float speedA = -300, speedB = -300, speedC = -300, speedD = -300;
    public float speed2A = -300, speed2B = -300, speed2C = -300, speed2D = -300;
    public float speed3A = -300, speed3B = -300, speed3C = -300, speed3D = -300;
    public float speed4A = -300, speed4B = -300, speed4C = -300, speed4D = -300;
    public float timeA, timeB, timeC, timeD;
    public float time2A, time2B, time2C, time2D;
    public float time3A, time3B, time3C, time3D;
    public float time4A, time4B, time4C, time4D;

    public int numA = -1, numB = -1, numC = -2, numD = -3;
    public int num2A = -4, num2B = -5, num2C = 6, num2D = -7;
    public int num3A = -8, num3B = -9, num3C = -9, num3D = -1;
    public int num4A = -2, num4B = -3, num4C = -4, num4D = -5;


    public int checkNumbers()
    {
        if (numA == -1 || numB == -1 || numC == -1 || numD == -1)
            return 1;

        if (numberSpins < 2)
            return -1;
        if (num2A == -1 || num2B == -1 || num2C == -1 || num2D == -1)
            return 2;

        if (numberSpins < 3)
            return -1;
        if (num3A == -1 || num3B == -1 || num3C == -1 || num3D == -1)
            return 3;

        if (numberSpins < 4)
            return -1;
        if (num4A == -1 || num4B == -1 || num4C == -1 || num4D == -1)
            return 4;
        return -1;
    }

    public GameObject[] buttonsCustomize;
    private void Awake()
    {
        Screen.SetResolution(1270, 720, false);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
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
    public void SetNumA(int num)
    {
        numA = num;
    }
    public void SetNumB(int num)
    {
        numB = num;
    }
    public void SetNumC(int num)
    {
        numC = num;
    }
    public void SetNumD(int num)
    {
        numD = num;
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
    public void SetNum2A(int num)
    {
        num2A = num;
    }
    public void SetNum2B(int num)
    {
        num2B = num;
    }
    public void SetNum2C(int num)
    {
        num2C = num;
    }
    public void SetNum2D(int num)
    {
        num2D = num;
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



    public void SetNum3A(int num)
    {
        num3A = num;
    }
    public void SetNum3B(int num)
    {
        num3B = num;
    }
    public void SetNum3C(int num)
    {
        num3C = num;
    }
    public void SetNum3D(int num)
    {
        num3D = num;
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
    public void SetNum4A(int num)
    {
        num4A = num;
    }
    public void SetNum4B(int num)
    {
        num4B = num;
    }
    public void SetNum4C(int num)
    {
        num4C = num;
    }
    public void SetNum4D(int num)
    {
        num4D = num;
    }
    #endregion
}
