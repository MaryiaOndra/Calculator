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
    private int maxInputNumber = 16;
    private int countMultyplayer = 3;
    private int countSignOperation = 0;

    private string operation;
    private string formatResult;
    private string tempFormulaText, tempFormulaResult;

    private bool isCalculatedResult;
    private bool dontSaveOperation;

    public void WriteToTextField()
    {
        inputFieldText.text = "" + result;
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

    public void SaveOperation(string op)
    {
        if (!isCalculatedResult)
        {
            operation = op;

            _ = !dontSaveOperation ? (formulaText.text += result + op) : (formulaText.text += op);

            if (operationsNumber < 1)
                tempResult = result;

            if (!isCalculatedResult && (operationsNumber >= 1))
                CalculateTemporaryResult();

            ResetMultyplayer();
            dontSaveOperation = false;
            operationsNumber++;
            result = 0.0f;
            countSignOperation = 0;
        }
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
                    ChangeFormulaText("1/");
                    result = 1 / result;
                    break;
                case "x²":
                    ChangeFormulaText("sqr");
                    result *= result;
                    break;
                case "√x":
                    ChangeFormulaText("√");
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
                    DeleteLastDigit();               
                    break;
            }

            WriteToTextField();
            countSignOperation++;
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
    public void SetMultyplayer()
    {
        multyplayer = 0.1f;
    }
    private void ResetMultyplayer()
    {
        countMultyplayer = 3;
        multyplayer = 1f;
    }

    private void ChangeFormulaText(string sign)
    {
        dontSaveOperation = true;

        if (countSignOperation <= 0)
        {
            tempFormulaText = formulaText.text;
            tempFormulaResult = sign + '(' + result + ')';
            formulaText.text += tempFormulaResult;
        }
        else
        {
            tempFormulaResult = sign + '(' + tempFormulaResult + ')';
            formulaText.text = tempFormulaText + tempFormulaResult;
        }
    }

    private void DeleteLastDigit()
    {
        string stringResult = result.ToString();
        string stringResultMinus1 = stringResult.Remove(stringResult.Length - 1, 1);
        if (stringResultMinus1.Length < 1)
            ResetInputField();
        else
            result = double.Parse(stringResultMinus1);
    }
}
