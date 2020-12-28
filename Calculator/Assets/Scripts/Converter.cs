using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Linq;

public class Converter : MonoBehaviour
{
    [SerializeField] private Calculator calculator;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text resultField;
    [SerializeField] private TMP_Dropdown dropdown;

    private List<ConverterEnums.LenghtTypes> lenghtTypesList;

    protected double convertResult = 0.0f;

    private void Awake()
    {
    }

    private void Update()
    {
       inputField.text = calculator.Result.ToString();
       resultField.text = convertResult.ToString();
    }

    public void ResetAll()
    {
        calculator.ResetInputField();
        convertResult = 0.0f;
    }

    public void ConvertLenght()
    {

    }
}
