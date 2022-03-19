using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* TODO 
Qu'est-ce que le GameObject mandelbulbPrefab ??
*/

public class PopulationController : MonoBehaviour
{
    public FractalMaster FM;  
    public List<DNA> population = new List<DNA>();
    public int populationSize = 9;
    public float cutoff = 0.3f;


    public void InitPopulation()
    {
        for(int i = 0; i < populationSize; i++)
            population.Add(new DNA());
    }

    public void NextGeneration()
    {
        //Create survivors
        int survivorCut = Mathf.RoundToInt(populationSize * cutoff);
        List<DNA> survivors = new List<DNA>();
        for(int i = 0; i < survivorCut; i++)
        {
            survivors.Add(GetFittest());
        }

        //Clear the population
        population.Clear();

        //Add new Fractals to the population
        int tmp_i = 0;
        while(population.Count <= populationSize)
        {
            population.Add(new DNA(survivors[tmp_i%survivors.Count], survivors[Random.Range(0, survivors.Count)]));
            tmp_i++;
        }

        //Delete survivors
        for(int i = 0; i < survivors.Count; i++)
        {
            survivors.Remove(survivors[i]);
        }
    }
    public void Start()
    {
        this.populationSize = 9;
        InitPopulation();
    }
    public void Update()
    {
       
    }

    DNA GetFittest()
    {
        float maxFitness = float.MinValue;
        int index = 0;
        for(int i = 0; i < population.Count; i++)
        {
            if(population[i].gene.fitness > maxFitness)
            {
                maxFitness = population[i].gene.fitness;
                index = i;
            }
        }
        DNA fittest = population[index];
        population.Remove(fittest);
        return fittest;
    }
}
