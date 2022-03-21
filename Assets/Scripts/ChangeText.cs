using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text changingText;
    public FractalMaster FM;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void UpdateText()
    {
        changingText.text = "Generation : " + (FM.currentGeneration+1) + " Mandelbulb n° : " + (FM.currentMandelbulb+1) + " Screenshot : SpaceBar";
    }
}
