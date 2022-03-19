using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public PopulationController PC;
    public AlgoGen AG;
    public FractalMaster FM;

    void Start()
    {
        //PC.Start();
        FM.setGenParams(PC.population[FM.currentMandelbulb].gene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenshotHandler.TakeScreenshot_static(Screen.width - 1, Screen.height - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            triggerAlgoGen(0.2f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            triggerAlgoGen(0.4f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            triggerAlgoGen(0.6f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            triggerAlgoGen(0.8f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            triggerAlgoGen(1.0f);
        }
    }

    void triggerAlgoGen(float f)
    {
        PC.population[FM.currentMandelbulb].gene.fitness = f;
        if (FM.currentMandelbulb == PC.populationSize-1)
            {
            FM.resetCurrentMandelbulbIdx();
            FM.increaseCurrentGenerationIdx();
            PC.NextGeneration();
            FM.setGenParams(PC.population[FM.currentMandelbulb].gene);
        }
        else
        {
            PC.population[FM.currentMandelbulb].hasFinished = true;
            AG.NextMandelbulb(PC.population[FM.currentMandelbulb+1].gene);
            FM.increaseCurrentMandelbulbIdx();
        }
    }
}
