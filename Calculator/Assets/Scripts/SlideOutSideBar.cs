using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class SlideOutSideBar : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool isShowed = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    public void ClickButton() 
    {
        if (!isShowed)
            Show();        
        else
            Hide();
    }

    private void Show() 
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
        isShowed = true;        
    }

    private void Hide() 
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        isShowed = false;        
    }
}
