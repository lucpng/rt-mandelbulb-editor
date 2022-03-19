using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalParams
{
    public bool isValidated = false;
    [Range(0,1)] public float fitness;

    //Params
    public float fractalPower; // = 10
    public float darkness; // = 70

    [Range(0, 1)] public float blackAndWhite;
    [Range(0, 1)] public float redA;
    [Range(0, 1)] public float greenA;
    [Range(0, 1)] public float blueA;
    [Range(0, 1)] public float redB;
    [Range(0, 1)] public float greenB;
    [Range(0, 1)] public float blueB;

    public FractalParams(float fPower, float d, float bw, float rA, float gA, float bA, float rB, float gB, float bB)
    {
        isValidated = false;
        fitness = 0.0f;

        fractalPower = fPower;
        darkness = d;

        blackAndWhite = bw;
        redA = rA;
        greenA = gA;
        blueA = bA;
        redB = rB;
        greenB = gB;
        blueB = bB;
    }
}
