using UnityEngine;

[CreateAssetMenu]
public class Crosshair : ScriptableObject
{
    [Header("CrossHair Color:")]
    public Color color;

    [Header("CrossHair:")]
    [Range(0f, 10f)] public float Size;
    [Range(0f, 5f)] public float Gap;
    [Range(0f, 7f)] public float Thinkness;
    [Range(0f, 7f)] public float OutLine;

    [Header("CrossHair Center Dot:")]
    public bool CenterDot;
}
