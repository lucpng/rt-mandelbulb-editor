using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private static ScreenshotHandler instance;
    private Camera myCamera;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    IEnumerator MakeScreenshot()
    {
        yield return new WaitForEndOfFrame();
        RenderTexture renderTexture = myCamera.targetTexture;
        // Make the texture
        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rect, 0, 0);
        // Save the image
        byte[] byteArray = renderResult.EncodeToJPG();
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "CameraScreenshot-" + timeStamp + ".jpg";
        System.IO.File.WriteAllBytes(Application.dataPath + "/" + fileName, byteArray);
        Debug.Log("Saved CameraScreenshot.jpg");
        // Clear all variables
        RenderTexture.ReleaseTemporary(renderTexture);
        myCamera.targetTexture = null;
    }

    private void TakeScreeshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        StartCoroutine(MakeScreenshot());
    }

    public static void TakeScreenshot_static(int width, int height)
    {
        instance.TakeScreeshot(width, height);
    }
}
