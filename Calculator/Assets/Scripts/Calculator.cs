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

    private DataTable dt = new DataTable();

    private string buttonValue;
    private string result;

    private bool isEqualPressed;
    private bool isNumberPressed;
    private bool isOperatorPressed;

    public void NumberPressed(string button) 
    {
        isNumberPressed = true;

        if (isOperatorPressed)
        {
            buttonValue = string.Empty;
            isOperatorPressed = false;
        }
        else if (isEqualPressed)
        {
            ResetAll();
            isEqualPressed = false;
        }      

        buttonValue += button;
        inputFieldText.text = buttonValue;
    }

    public void OperatorPressed(string operatorSign) 
    {
        isOperatorPressed = true;

        formulaText.text += buttonValue;
        
        //_ = double.TryParse(buttonValue, out double buttonValueDouble);

        switch (operatorSign)
        {
            case "+":
            case "-":
            case "/":
            case "*":
                formulaText.text += operatorSign;
                break;

            case "%":
                break;

            case "1/x":
                break;

            case "√x":
                break;
            default:
                break;
        }
        isNumberPressed = false;
    }

    public void ResetAll()
    {
        buttonValue = string.Empty;
        inputFieldText.text = string.Empty;
        formulaText.text = string.Empty;
    }

    public void ResetInputLine()
    {
        if (!isEqualPressed)
        {
            inputFieldText.text = string.Empty;
            buttonValue = string.Empty;
        }
        else
            ResetAll();
    }

    public void ComputeResult()
    {
        if (!isEqualPressed)
        {
            formulaText.text += buttonValue;        
            isEqualPressed = true;
            Debug.Log(formulaText.text);
            result = (dt.Compute(formulaText.text, string.Empty)).ToString();
            formulaText.text += "=";
            inputFieldText.text = result;
        }
    }
}
