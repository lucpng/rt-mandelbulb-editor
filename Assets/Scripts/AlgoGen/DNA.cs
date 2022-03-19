using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
    public FractalParams gene;
    public bool hasFinished;

    public DNA()
    {
        // gene.Add(new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)));
        gene = new FractalParams(
            Random.Range(0.0f, 20.0f),
            Random.Range(0.0f, 100.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f)
        );
        hasFinished = false;
    }
    public DNA(DNA parent, DNA partner, float mutationRate = 0.5f)
    {
        float mutationChance = Random.Range(0.0f, 1.0f);
        if (mutationChance <= mutationRate)
        {
            gene = new FractalParams(
                Random.Range(0.0f, 20.0f),
                Random.Range(0.0f, 100.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );
        }
        else
        {
            int chance = Random.Range(0, 2);
            if (chance == 0)
            {
                gene = parent.gene;
            }
            else
            {
                gene = partner.gene;
            }
        }
        hasFinished = false;
    }
}
