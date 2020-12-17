using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalculatorPanels : MonoBehaviour
{
    private string standartType = "Standart";
    private string scientificType = "Scientific";

    private GameObject[] scientificPanels;
    private GameObject[] stantartPanels;

    private void Awake()
    {
        scientificPanels = GameObject.FindGameObjectsWithTag(scientificType);
        stantartPanels = GameObject.FindGameObjectsWithTag(standartType);

        HidePanel(scientificPanels);
    }

    private void HidePanel(GameObject[] panels)
    {
        foreach (var panel in panels)
            panel.SetActive(false);
    }

    private void ShowPanel(GameObject[] panels) 
    {
        foreach (var panel in panels)
            panel.SetActive(true);
    }
}
