using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticMandelbulb : MonoBehaviour
{
    public Camera Camera;
    public DNA dna;
    public bool hasFinished;

    public void InitMandelbulb(DNA newDna)
    {
        dna = newDna;
        hasFinished = false;
    }
    private void Update()
    {

    }

    public float fitness
    {
        get
        {
            return dna.gene.fitness;
        }
    }

    public void setFinished()
    {
        hasFinished = true;
    }

}
/*while (population.Count <= populationSize)
{

    //for(int i = 0; i < survivors.Count; i++)
    //{
    //population.Add(new DNA(survivors[i], survivors[Random.Range(0, survivors.Count)]));
    population.Add(new DNA(survivors[tmp_i % survivors.Count], survivors[Random.Range(0, survivors.Count)]));
    //    if(population.Count >= populationSize)
    //    {
    //        break;
    //    }
    //}
    tmp_i++;
}
for (int i = 0; i < survivors.Count; i++)
{
    survivors.Remove(survivors[i]);
}
*/