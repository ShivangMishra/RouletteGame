using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evereal.VideoCapture;
public class StartRecord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VideoCapture vc = GameObject.Find("VideoCapture").GetComponent<VideoCapture>();
        vc.StartCapture();
    }
}
