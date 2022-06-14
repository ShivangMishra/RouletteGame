using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Force", 8f, 2.2f);
        Invoke("StopForce", 12);
    }
    public void Force()
    {
        Debug.Log("Force");
        rb.AddForce(transform.up*3, ForceMode.Impulse);
    }
    public void StopForce()
    {
        CancelInvoke();
    }

}
