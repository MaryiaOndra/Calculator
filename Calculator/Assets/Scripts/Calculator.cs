using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Calculator : MonoBehaviour
{
    //[SerializeField] private TMP_Text inputFieldText;
    [SerializeField] private TMP_InputField inputFieldText;
    private string buttonValue;

    public void ButtonPressed(string button) 
    {
        buttonValue = button;
        inputFieldText.text += buttonValue;
    }
}
