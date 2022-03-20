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
        FM.setGenParams(PC.population[FM.currentMandelbulb].gene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenshotHandler.TakeScreenshot_static(Screen.width - 1, Screen.height - 1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void triggerMark(float fitness)
    {
        triggerAlgoGen(fitness);
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
