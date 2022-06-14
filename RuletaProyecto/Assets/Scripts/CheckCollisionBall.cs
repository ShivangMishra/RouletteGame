using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionBall : MonoBehaviour
{

    public RouletteRotator rouletteRotator;
    public int ballNumber;
    bool numberRegistred;
    private void OnTriggerStay(Collider other)
    {
        if (rouletteRotator.CheckCollision && !numberRegistred)
        {
            rouletteRotator.RegisterNumber(ballNumber, int.Parse(other.tag));
            numberRegistred = false;
        }
    }
}
