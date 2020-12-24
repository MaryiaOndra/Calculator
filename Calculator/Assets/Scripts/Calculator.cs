using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Data;
using UnityEngine.SceneManagement;
using System;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldText;
    [SerializeField] private TMP_Text formulaText;

    private double result = 0.0f;
    private double tempResult = 0.0f;
    private float multyplayer = 1;
    private int operationsNumber = 0;
    private int maxInputNumber = 10;
    private int countMultyplayer = 3;

    private string operation;
    private string formatResult;

    private bool isCalculatedResult;
    private bool dontSaveOperation;

    public void WriteToTextField()
    {
        inputFieldText.text = "" + result;
    }

    public void ResetAll() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetInputField() 
    {
        if (!isCalculatedResult)
        {
            result = 0.0f;
            multyplayer = 1;
            isCalculatedResult = false;
            WriteToTextField();
        }
        else 
            ResetAll();
    }

    public void SaveOperation(string op)
    {
        if (!isCalculatedResult)
        {
            operation = op;

            formulaText.text += result + op;

            if (operationsNumber < 1)
                tempResult = result;

            if (!isCalculatedResult && (operationsNumber >= 1))
                CalculateTemporaryResult();

            ResetMultyplayer();
            dontSaveOperation = false;
            operationsNumber++;
            result = 0.0f;
        }
    }

    public void AddDigit(int d)
    {
        if (result.ToString().Length <= maxInputNumber)
        {
            if (isCalculatedResult)
            {
                result = 0.0f;
                multyplayer = 1;
                formulaText.text = string.Empty;
                operationsNumber = 0;
                isCalculatedResult = false;
            }

            if (multyplayer == 1)
            {
                result *= 10;
                result += d;
            }
            else
            {                
                double draftDigit = d * multyplayer;
                double clearDigit = Math.Round((float)draftDigit, countMultyplayer);
                result += clearDigit;
                multyplayer *= 0.1f;
                countMultyplayer++;
            }

            WriteToTextField();
        }
    }

    public void SetMultyplayer() 
    {
        multyplayer = 0.1f;
    }
    private void ResetMultyplayer() 
    {
        countMultyplayer = 3;
        multyplayer = 1f;
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

    public void CalculateSignOperations(string sign) 
    {
        if (!isCalculatedResult)
        {
            switch (sign)
            {
                case "1/x":
                    dontSaveOperation = true;
                    formulaText.text += $"1/({result})";
                    tempResult = 1 / result;
                    break;
                case "x²":
                    dontSaveOperation = true;
                    formulaText.text += $"sqr({result})";
                    result *= result;
                    break;
                case "√x":
                    dontSaveOperation = true;
                    formulaText.text += $"√({result})";
                    result = Mathf.Sqrt((float)result);
                    break;
                case "%":
                    result = tempResult % result;
                    formulaText.text += result;
                    break;
                case "+/-":
                    result *= -1;
                    break;
                case "delete":
                    string stringResult= result.ToString();
                    string stringResultMinus1 = stringResult.Remove(stringResult.Length - 1, 1);
                    if (stringResultMinus1.Length < 1)
                        ResetInputField();
                    else
                        result = double.Parse(stringResultMinus1);
                    
                    break;
            }

            WriteToTextField();
        }
    }

    public void CalculateResult()
    {
        if (!isCalculatedResult)
        {
            isCalculatedResult = true;

            if (dontSaveOperation)
            {
                formulaText.text += "=";
                tempResult = result;
            }
            else 
            {
                formulaText.text += result + "=";
            }

            CalculateTemporaryResult();
            result = tempResult;
            WriteToTextField();
        }
    }
}
