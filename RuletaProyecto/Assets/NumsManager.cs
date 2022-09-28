using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumsManager : MonoBehaviour
{
    public void handleNums1(string numStr)
    {
        if (numStr.Length < 4)
        {
            return;
        }
        int num = int.Parse(numStr);
        int numD = num % 10;
        num /= 10;
        int numC = num % 10;
        num /= 10;
        int numB = num % 10;
        num /= 10;
        int numA = num % 10;
        GameManager.instance.SetNumA(numA);
        GameManager.instance.SetNumB(numB);
        GameManager.instance.SetNumC(numC);
        GameManager.instance.SetNumD(numD);
    }

    public void handleNums2(string numStr)
    {
        if (numStr.Length < 4)
        {
            return;
        }
        int num = int.Parse(numStr);
        int numD = num % 10;
        num /= 10;
        int numC = num % 10;
        num /= 10;
        int numB = num % 10;
        num /= 10;
        int numA = num % 10;
        GameManager.instance.SetNum2A(numA);
        GameManager.instance.SetNum2B(numB);
        GameManager.instance.SetNum2C(numC);
        GameManager.instance.SetNum2D(numD);
    }

    public void handleNums3(string numStr)
    {
        if (numStr.Length < 4)
        {
            return;
        }
        int num = int.Parse(numStr);
        int numD = num % 10;
        num /= 10;
        int numC = num % 10;
        num /= 10;
        int numB = num % 10;
        num /= 10;
        int numA = num % 10;
        GameManager.instance.SetNum3A(numA);
        GameManager.instance.SetNum3B(numB);
        GameManager.instance.SetNum3C(numC);
        GameManager.instance.SetNum3D(numD);
    }

    public void handleNums4(string numStr)
    {
        if (numStr.Length < 4)
        {
            return;
        }
        int num = int.Parse(numStr);
        int numD = num % 10;
        num /= 10;
        int numC = num % 10;
        num /= 10;
        int numB = num % 10;
        num /= 10;
        int numA = num % 10;
        GameManager.instance.SetNum4A(numA);
        GameManager.instance.SetNum4B(numB);
        GameManager.instance.SetNum4C(numC);
        GameManager.instance.SetNum4D(numD);
    }
}
