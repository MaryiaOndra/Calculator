using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Dropdown))]
public class LenghtDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private List<string> optionsNames;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        CreateOptions();
        AddNewOptionsToList();
        foreach (var item in optionsNames)
        {
            Debug.Log("Name:" + dropdown.name + "Value:" + dropdown.value);
        }
    }

    private void AddNewOptionsToList()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(optionsNames);
    }

    private void CreateOptions()
    {
        string[] names = Enum.GetNames(typeof(ConverterEnums.LenghtTypes));
        optionsNames = new List<string>(names);
    }

    public void ConvertLenght(int index) 
    {
        switch (index)
        {
            case (int)ConverterEnums.LenghtTypes.Nanometers:
                break;
            case (int)ConverterEnums.LenghtTypes.Microns:
                break;
            case (int)ConverterEnums.LenghtTypes.Milimeters:
                break;
            default:
                break;
        }
    }
}


