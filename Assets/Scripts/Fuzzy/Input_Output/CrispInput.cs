using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyLogic
{
    /// <summary>
    /// Input to the fuzzy system
    /// </summary>
    public class CrispInput 
    {

        public const int NumberOfVariables = 3;
        public enum Inputs
        {
            Input1
            , Input2
            , Input3
            //, Input4
            //, Input5
            //, Input6
            //, Input7
            //, Input8
            //, Input9
            //, Input10
        }


        private float[] values = new float[NumberOfVariables];

        public float this[Inputs InputVariable]
        {
            get { return values[(int)InputVariable]; }
            set { values[(int)InputVariable] = value; }
        }
    } 
    
    
    /// <summary>
    /// Outputs to the fuzzy system
    /// </summary>
    public class CrispOutput
    {

        public const int NumberOfVariables = 1;
        public enum Outputs
        {
            Output1
            //, Output2
            //, Output3
            //, Output4
            //, Output5
            //, Output6
            //, Output7
            //, Output8
            //, Output9
            //, Output10
        }


        private float[] values = new float[NumberOfVariables];

        public float this[Outputs InputVariable]
        {
            get { return values[(int)InputVariable]; }
            set { values[(int)InputVariable] = value; }
        }
    }
}
