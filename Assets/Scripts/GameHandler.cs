using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenshotHandler.TakeScreenshot_static(Screen.width - 1, Screen.height - 1);
        }
    }
}
