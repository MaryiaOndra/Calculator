using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainNumberPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFieldText;
    //[SerializeField] private TMP_Text formulaText;

    private double result = 0.0f;
    //private double tempResult = 0.0f;
    private float multyplayer = 1;
    private int maxInputNumber = 16;
    private int countMultyplayer = 3;
    //private int countSignOperation = 0;

    //private string operation;
    //private string formatResult;
    //private string tempFormulaText, tempFormulaResult;

    private bool isCalculatedResult;
    //private bool dontSaveOperation;

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
                //formulaText.text = string.Empty;
                //operationsNumber = 0;
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
