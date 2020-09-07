using System.IO;
using UnityEngine;
using System;
using System.Globalization;
 
public class ScreenshotController : MonoBehaviour
{
    public KeyCode screenshotKey;
    public Camera _camera;
 
    void Start () {
      
    }
 
    private void LateUpdate()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            DateTime localDate = DateTime.Now;
            ScreenCapture.CaptureScreenshot(System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")  + "_screenshot.png");
        }
    }
 
    
}