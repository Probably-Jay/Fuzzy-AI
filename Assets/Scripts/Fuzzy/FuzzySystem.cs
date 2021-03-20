using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyLogic
{

    public class FuzzySystem : MonoBehaviour
    {
        private Fuzifier fuzifier = new Fuzifier();
        private InferenceEngine inferenceEngine = new InferenceEngine();
        private Defuzzifier defuzzifier = new Defuzzifier();

        private FunctionCurve functionCurve = null;
        private FuzzyRulesList fuzzyRulesList = null;



        public FunctionCurve FunctionCurve { get => functionCurve; 
            set
            {
                functionCurve = value;
                fuzifier.inputFunction = value;
            }
        }
        public FuzzyRulesList FuzzyRulesList { get => fuzzyRulesList;
            set
            {
                fuzzyRulesList = value;
                inferenceEngine.fuzzyRules = value;
            }
        }


        /// <summary>
        /// Compute fuzzy logic on the <paramref name="crispInput"/>, using the current <see cref="FunctionCurve"/> and <see cref="FuzzyRulesList"/>
        /// </summary>
        public CrispOutput FuzzyCompute(CrispInput crispInput)
        {
            FuzzyInputData fuzzyInput = fuzifier.Fuzzify(crispInput);
            FuzzyOutputData fuzzyOutput = inferenceEngine.ApplyRulset(fuzzyInput);
            CrispOutput crispOutput = defuzzifier.Defuzzify(fuzzyOutput);
            return crispOutput;
        }
    }
}
