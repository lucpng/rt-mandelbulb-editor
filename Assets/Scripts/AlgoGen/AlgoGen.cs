using System.Collections;
using UnityEngine;

public class AlgoGen : MonoBehaviour
{
        public Light dLight;
        public FractalMaster FM;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void NextMandelbulb(FractalParams fractalParams)
        {
            FM.setGenParams(fractalParams);            
        }
    }
