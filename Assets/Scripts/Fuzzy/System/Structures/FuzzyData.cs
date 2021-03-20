using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FuzzyLogic
{

    /// <summary>
    /// Structure holding the data after being fuzzified
    /// </summary>
    [System.Serializable]
    internal class FuzzyInputData
    {

        public FuzzyInputData()
        {
            values = new FuzzyNumber[NumberOfVariables];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new FuzzyNumber();
            }
        }

        public const int NumberOfVariables = CrispInput.NumberOfVariables;

        private FuzzyNumber[] values;

        public FuzzyNumber this[CrispInput.Inputs InputVariable]
        {
            get { return values[(int)InputVariable]; }
            set { values[(int)InputVariable] = value; }
        }

    }
    
    /// <summary>
    /// Structure holding the fuzzy data after the rules are applied
    /// </summary>
    [System.Serializable]
    internal class FuzzyOutputData
    {
        public FuzzyOutputData()
        {
            values = new FuzzyNumber[NumberOfVariables];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new FuzzyNumber();
            }
        }

        public const int NumberOfVariables = CrispOutput.NumberOfVariables;

        private FuzzyNumber[] values = new FuzzyNumber[NumberOfVariables];

        public FuzzyNumber this[CrispOutput.Outputs InputVariable]
        {
            get { return values[(int)InputVariable]; }
            set { values[(int)InputVariable] = value; }
        }

    }

    ///// <summary>
    ///// Parent class for fuzzy data
    ///// </summary>
    //[System.Serializable]
    //abstract internal class FuzzyData 
    //{ 
    
    //}


    /// <summary>
    /// A fuzzy number
    /// </summary>
    internal class FuzzyNumber
    {



        public const int NumberOfMemberships = 5;

        public static readonly Dictionary<FuzzyUtility.FuzzyStates, float> NormalisedStateValues = new Dictionary<FuzzyUtility.FuzzyStates, float>() 
        {
            {FuzzyUtility.FuzzyStates.LP, 1f }
            , {FuzzyUtility.FuzzyStates.MP, 0.5f }
            , {FuzzyUtility.FuzzyStates.Z, 0f }
            , {FuzzyUtility.FuzzyStates.MN, -0.5f }
            , {FuzzyUtility.FuzzyStates.LN, -1f }
        };


        private float[] values = new float[NumberOfMemberships];

        public float this[FuzzyUtility.FuzzyStates state]
        {
            get { return values[(int)state]; }
            set { values[(int)state] = value; }
        }

        public void Normalise()
        {
            float mag = Magnitude;

            for (int i = 0; i < values.Length; i++)
            {
                values[i] /= mag;
            }

        }

        public float Magnitude
        {
            get
            {
                float total = 0;
                foreach (var value in values)
                {
                    total += value * value;
                }

                var mag = Mathf.Sqrt(total);
                return mag;
            }
        }  
        
        public float Sum
        {
            get
            {
                float total = 0;
                foreach (var value in values)
                {
                    total += value;
                }
                return total;
            }
        }
    }
}

