using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : Base<bool>
{
    [SerializeField] private Toggle toggle;

    public override void OnvalueChange(bool Value)
    {
        Settings.FPSCounter = Value;
        
    }

    protected override void Initialize()
    {
        toggle.isOn = Settings.FPSCounter;
    }
}
