using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogic;
using System;

[RequireComponent(typeof(FuzzySystem))]
public class Test : MonoBehaviour
{
    private const int Input1Max = 10;
    private const int Input1Min = -5;
    private const int Input2Max = 5;
    private const int Input2Min = -5;
    FuzzySystem fuzzySystem;
    [SerializeField,Range(Input1Min, Input1Max)] float crispInput1;
    [SerializeField, Range(Input2Min, Input2Max)] float crispInput2;
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
        float[] minValues = new float[CrispInput.NumberOfVariables] { Input1Min, Input2Min, -1 };
        float[] neutralValues = new float[CrispInput.NumberOfVariables] { 0,0,0 };
        float[] maxValues = new float[CrispInput.NumberOfVariables] { Input1Max,Input2Max,1 };



        CrispInput crispInput = fuzzySystem.BuildInputNormalisedUneven(new float[]{ crispInput1,crispInput2,crispInput3},minValues,neutralValues,maxValues);

        Debug.Log($"In log {crispInput1} -> {crispInput[CrispInput.Inputs.Input1]}");
 
        CrispOutput normalisedCrispOutput = fuzzySystem.FuzzyCompute(crispInput);

        CrispOutput unNormalisedOutput = fuzzySystem.UnNormaliseOutputUneven(normalisedCrispOutput, minValues, neutralValues, maxValues);


        Debug.Log($"Out log {normalisedCrispOutput[CrispOutput.Outputs.Output1]} -> {unNormalisedOutput[CrispOutput.Outputs.Output1]}" );
    }
}
