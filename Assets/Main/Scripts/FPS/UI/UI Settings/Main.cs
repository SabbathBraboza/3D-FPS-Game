using UnityEngine;
using UnityEngine.Events;

public class Main : MonoBehaviour
{
    public Settings settings;

    public UnityEvent OnInitialize;

    private void Start()
    {
        OnInitialize.Invoke();
        HandleQuality();
    }

    public void HandleQuality() => QualitySettings.SetQualityLevel(settings.QualityIndex); 
}
