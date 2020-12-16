using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SlideOutSideBar : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 hidePosition;
    private Vector3 showPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        hidePosition = rectTransform.position;
    }

    public void Show() 
    {
        rectTransform.position = showPosition;
    }

    public void Hide() 
    {
        rectTransform.position = hidePosition;
    }
}
