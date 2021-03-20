using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogic;
using System;

[RequireComponent(typeof(FuzzySystem))]
public class Test : MonoBehaviour
{
    FuzzySystem fuzzySystem;
    [SerializeField,Range(-1,1)] float crispInput1;
    [SerializeField, Range(-1, 1)] float crispInput2;
    [SerializeField, Range(-1, 1)] float crispInput3;

    [SerializeField] FuzzyRulesList rulesList;
    [SerializeField] FunctionCurve inputCurve;

    // Start is called before the first frame update
    void Awake()
    {
        fuzzySystem = GetComponent<FuzzySystem>();
        fuzzySystem.FunctionCurve = inputCurve;
        fuzzySystem.FuzzyRulesList = rulesList;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RunFuzzy();
        }
    }

    private void RunFuzzy()
    {
        CrispInput crispInput = new CrispInput();
        crispInput[CrispInput.Inputs.Input1] = crispInput1;
        crispInput[CrispInput.Inputs.Input2] = crispInput2;
        crispInput[CrispInput.Inputs.Input3] = crispInput3;

        CrispOutput crispOutput = fuzzySystem.FuzzyCompute(crispInput);
        Debug.Log($"Log {crispOutput[CrispOutput.Outputs.Output1]}" );
    }
}
