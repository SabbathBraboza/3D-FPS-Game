using System.Linq;
using TMPro;
using UnityEngine;

public class Resolution : Base<int>
{
    [SerializeField] private TMP_Dropdown dropdown;

    protected override void OnEnable()
    {
        base.OnEnable();
        dropdown.onValueChanged.AddListener(OnvalueChange);
    }
    protected override void OnDisable()
    {
        base.OnDisable ();
        dropdown.onValueChanged.RemoveListener(OnvalueChange);
    }

    protected override void Initialize()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(Settings.Resolutions.Select(res => $"{res.width} X { res.height} - {res.refreshRateRatio}").ToList());

        dropdown.value = Settings.ResolutionIndex;
    }

     public override void OnvalueChange(int Value)
    {
        Settings.ResolutionIndex = Value;

        var Resolution = Settings.Resolutions[Value];
        Screen.SetResolution(Resolution.width, Resolution.height, FullScreenMode.ExclusiveFullScreen,Resolution.refreshRateRatio);
    }
}
