using UnityEngine;


[CreateAssetMenu]
public class Settings : ScriptableObject
{
    public int ResolutionIndex;

    public bool FPSCounter;

    public UnityEngine.Resolution[] Resolutions;

    private void OnEnable()
    {
        Resolutions = Screen.resolutions;
    }
}
