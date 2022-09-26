using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evereal.VideoCapture;

public class ResolutionManager : MonoBehaviour
{
    private int width;
    private int height;
    public string filePath;

    public string getFilePath()
    {
        return filePath;
    }

    public void setFilePath(string path)
    {
        filePath = path;
    }

    private int[,] resolutions = new int[,]
    {
        { 480, 320 },
        { 640, 480 },
        { 720, 480 },
        { 1280, 720 },
        { 1920, 1080 }
    };
    private void Start()
    {
        SetRes(0);
    }

    public void SetRes(int i)
    {
        width = resolutions[i, 0];
        height = resolutions[i, 1];
        VideoCapture vc = GameObject.Find("VideoCapture").GetComponent<VideoCapture>();
        vc.resolutionPreset = ResolutionPreset.CUSTOM;
        // Screen.SetResolution(width, height, false);
        vc.frameWidth = width;
        vc.frameHeight = height;
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }
}
