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
    public DNA(DNA parent, DNA partner, float mutationRate = 0.2f)
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
            int chance = Random.Range(0, 4);
            if (chance == 0)
            {
                //gene = parent.gene;
                gene = new FractalParams(
                    parent.gene.fractalPower + Random.Range(-1.0f, 1.0f),
                    parent.gene.darkness + Random.Range(-3.0f, 3.0f),
                    parent.gene.blackAndWhite + Random.Range(-1.0f, 1.0f),
                    parent.gene.redA + Random.Range(-0.1f, 0.1f),
                    parent.gene.greenA + Random.Range(-0.1f, 0.1f),
                    parent.gene.blueA + Random.Range(-0.1f, 0.1f),
                    parent.gene.redB + Random.Range(-0.1f, 0.1f),
                    parent.gene.greenB + Random.Range(-0.1f, 0.1f),
                    parent.gene.blueB + Random.Range(-0.1f, 0.1f)
                );
            }
            else if (chance == 1)
            {
                //gene = partner.gene;
                gene = new FractalParams(
                    partner.gene.fractalPower + Random.Range(-1.0f, 1.0f),
                    partner.gene.darkness + Random.Range(-3.0f, 3.0f),
                    partner.gene.blackAndWhite + Random.Range(-1.0f, 1.0f),
                    partner.gene.redA + Random.Range(-0.1f, 0.1f),
                    partner.gene.greenA + Random.Range(-0.1f, 0.1f),
                    partner.gene.blueA + Random.Range(-0.1f, 0.1f),
                    partner.gene.redB + Random.Range(-0.1f, 0.1f),
                    partner.gene.greenB + Random.Range(-0.1f, 0.1f),
                    partner.gene.blueB + Random.Range(-0.1f, 0.1f)
                );
            }
            else
            {
                gene = new FractalParams(
                    Random.Range(parent.gene.fractalPower, partner.gene.fractalPower),
                    Random.Range(parent.gene.darkness, partner.gene.darkness),
                    Random.Range(parent.gene.blackAndWhite, partner.gene.blackAndWhite),
                    Random.Range(parent.gene.redA, partner.gene.redA),
                    Random.Range(parent.gene.greenA, partner.gene.greenA),
                    Random.Range(parent.gene.blueA, partner.gene.blueA),
                    Random.Range(parent.gene.redB, partner.gene.redB),
                    Random.Range(parent.gene.greenB, partner.gene.greenB),
                    Random.Range(parent.gene.blueB, partner.gene.blueB)
                );
            }
        }
        hasFinished = false;
    }
}
