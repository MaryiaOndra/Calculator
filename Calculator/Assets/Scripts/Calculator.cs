using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Data;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldText;
    [SerializeField] private TMP_Text formulaText;

    private double result = 0.0f;
    private double tempResult = 0.0f;
    private float multyplayer = 1;

    private string operation;
    private string formatResult;


    private int operationsNumber = 0;

    private bool isCalculatedResult; 

    public void WriteToTextField()
    {
        if (multyplayer == 1)
        {
            inputFieldText.text = "" + result;
        }
        else
        {
            formatResult = string.Format("{0:0.00}", result);
            inputFieldText.text = "" + formatResult;
        }
    }

    public void ClearResult() 
    {
        result = 0.0f;
        multyplayer = 1;
        formulaText.text = string.Empty;
        operationsNumber = 0;
        WriteToTextField();
    }

    public void SaveOperation(string op) 
    {
        operation = op;

        if (multyplayer == 1)
            formulaText.text += result + op;
        else
            formulaText.text += formatResult + op;

        if (operationsNumber < 1)
            tempResult = result;

        if (!isCalculatedResult && (operationsNumber >= 1))
            CalculateTemporaryResult();

        operationsNumber++;
        multyplayer = 1;
        result = 0.0f;
    }

    public void AddDigit(int d)
    {
        if (multyplayer == 1)
        {
            result *= 10;
            result += d;
        }
        else
        {
            result += d * multyplayer;
            multyplayer *= 0.1f;
        }

        WriteToTextField();
    }

    public void SetMultyplayer() 
    {
        multyplayer = 0.1f;
    }

    public void CalculateTemporaryResult() 
    {
        switch (operation)
        {
            case "+":
                tempResult = tempResult + result;
                break;
            case "-":
                tempResult = tempResult - result;
                break;
            case "*":
                tempResult = tempResult * result;
                break;
            case "/":
                tempResult = tempResult / result;
                break;             
        }
    }

    public void CalculateResult()
    {
        if (!isCalculatedResult)
        {
            formulaText.text += result + "=";
            CalculateTemporaryResult();

            result = tempResult;
            WriteToTextField();

            operation = string.Empty;
            multyplayer = 1;
            operationsNumber = 0;
            isCalculatedResult = true;
        }
    }
}
