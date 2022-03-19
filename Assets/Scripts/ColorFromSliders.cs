using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFromSliders : MonoBehaviour
{
    public GameObject ImageColor;
    public Slider red;
    public Slider green;
    public Slider blue;
   
    // Update is called once per frame
    void Update()
    {
        ImageColor.GetComponent<Image>().color = new Color(red.value, green.value, blue.value, 1.0f);
        
    }
}
