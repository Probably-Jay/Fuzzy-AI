using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FuzzyLogic
{
    /// <summary>
    /// Applies the rule base on many fuzzy sets to determine behaviour
    /// </summary>
    internal class InferenceEngine
    {

        public FuzzyRulesList fuzzyRules;

        public FuzzyOutputData ApplyRulset(FuzzyInputData fuzzyInput)
        {
            List<FuzzyOutputData> unaggragatedFuzzyOuputs = new List<FuzzyOutputData>();

            
            foreach (SimpleFuzzyRule rule in fuzzyRules.rules)
            {
                FuzzyOutputData fuzzyOutput = new FuzzyOutputData();

                float value = 0;
                switch (rule.isOrIsNot)
                {
                    case SimpleFuzzyRule.IsOrIsNot.Is:
                        value = fuzzyInput[rule.input][rule.inputState];
                        break;
                    case SimpleFuzzyRule.IsOrIsNot.IsNot:
                        value = (!fuzzyInput[rule.input])[rule.inputState];
                        break;
                }

                 
                fuzzyOutput[rule.output][rule.outputState] = value;


                unaggragatedFuzzyOuputs.Add(fuzzyOutput);
            }


            FuzzyOutputData outputData = AgragateFuzzyOutputs(unaggragatedFuzzyOuputs);

            return outputData;

        }

        /// <summary>
        /// Agragates a list of <see cref="FuzzyLogic.FuzzyOutputData"/> by taking the maximum value of each <see cref="FuzzyLogic.FuzzyNumber.FuzzyStates"/> for each <see cref="FuzzyLogic.CrispOutput.Outputs"/> 
        /// </summary>
        /// <returns>A single <see cref="FuzzyLogic.FuzzyOutputData"/></returns>
        private FuzzyOutputData AgragateFuzzyOutputs(List<FuzzyOutputData> unaggragatedFuzzyOuputs)
        {
            FuzzyOutputData outputData = new FuzzyOutputData();

            foreach (CrispOutput.Outputs outputVariable in System.Enum.GetValues(typeof(CrispOutput.Outputs)))
            {
                foreach (FuzzyUtility.FuzzyStates membershipState in System.Enum.GetValues(typeof(FuzzyUtility.FuzzyStates)))
                {
                    outputData[outputVariable][membershipState] = GetMaxVariableMembershipState(outputVariable, membershipState, unaggragatedFuzzyOuputs);
                }
            }
            return outputData;
        }

        /// <summary>
        /// Regular find max algorythm on the values provided
        /// </summary>
        private float GetMaxVariableMembershipState(CrispOutput.Outputs outputVariable, FuzzyUtility.FuzzyStates membershipState, List<FuzzyOutputData> unaggragatedFuzzyOuputs)
        {
            float cur;
            float max = 0;
            foreach (FuzzyOutputData fuzzyOutput in unaggragatedFuzzyOuputs)
            {
                cur = fuzzyOutput[outputVariable][membershipState];
                if (cur <= max)
                {
                    continue;
                }
                else
                {
                    max = cur;
                }
            }
            return max;
        }


    }


}
