using Emp37.Utility;
using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair_Manager : MonoBehaviour
{
    [Header("Asset:")]
    [SerializeField] private Crosshair crosshair;

    [Header("RectTransforms:")]
    [SerializeField] private RectTransform Top;
    [SerializeField] private RectTransform Left;
    [SerializeField] private RectTransform Right;
    [SerializeField] private RectTransform Buttom;
    [SerializeField] private RectTransform Center;

    [Button]
    public void ValidateCrossHair()
    {
        //Gap
        Top.localPosition = new(x: 0f, y: crosshair.Gap);
        Left.localPosition = new(x: -crosshair.Gap, y: 0f);
        Buttom.localPosition = new(x: 0f, y: -crosshair.Gap);
        Right.localPosition = new(x: crosshair.Gap, y: 0f);

        //Size
        ApplyLength(Top,true);
        ApplyLength(Left,false);
        ApplyLength(Right,false);
        ApplyLength(Buttom,true);
        ApplyLength(Center,true);

        //Thinkness
        var outline = crosshair.OutLine * Vector2.one;
        Top.sizeDelta += outline;
        Left.sizeDelta += outline;  
        Right.sizeDelta += outline;
        Buttom.sizeDelta += outline;
        Center.sizeDelta += outline;

        //Color
        ApplyColor(Top);
        ApplyColor(Left);
        ApplyColor(Right);
        ApplyColor(Buttom);
        ApplyColor(Center);

        //Center Dot
        var Dot = crosshair.CenterDot;
        Center.gameObject.SetActive(Dot);
        if(Dot)
        {
            Array.ForEach(Center.GetComponentsInChildren<RectTransform>(true),
            element=> element.sizeDelta= new (x:crosshair.Thinkness, y:crosshair.Thinkness));
        }
    }

    private void ApplyLength(RectTransform transform, bool value)
    {
        foreach(var element in transform.GetComponentsInChildren<RectTransform>(true))
        {
            element.sizeDelta = value ? new(x: crosshair.Thinkness, y: crosshair.Size): new (x:crosshair.Size, y:crosshair.Thinkness);
        }
    }
    private void ApplyColor(RectTransform transform)
    {
        if (transform.TryGetComponent(out Image image))
        {
            image.color = crosshair.color;
        }
    }
}
