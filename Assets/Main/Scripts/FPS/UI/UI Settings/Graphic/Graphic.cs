using UnityEngine;

public class Graphic : Base<int>
{
    [SerializeField] private ArrowOption Option;

    public override void OnvalueChange(int Value)
    {
        if (Settings.QualityIndex == Value) return;

        Settings.QualityIndex = Value;
        QualitySettings.SetQualityLevel(Settings.QualityIndex);
    }


    protected override void Initialize()
    {
      Option.Value = Settings.QualityIndex;
    }
}
