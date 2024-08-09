using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Emp37.Utility;
using UnityEngine.Events;

public class ArrowOption : MonoBehaviour
{
    [SerializeField] private Button Pervious;
    [SerializeField] private Button Next;
    [SerializeField] private TMP_Text Current;

    [Label("")] public string[] Options;
    [SerializeField, Readonly] private int value;

     public UnityEvent<int> OnValueChange;

    public int Value
    {
        get => value;
        set
        {
            this.value = Mathf.Clamp(value, 0, Options.Length - 1);
            Current.text = Options[this.value];
            OnValueChange.Invoke(this.value);
        }
    }

    private void OnEnable()
    {
        Current.text = Options[Value];

        Next.onClick.AddListener(GoNext);
        Pervious.onClick.AddListener(GoPervious);
    }

    private void OnDisable()
    {
        Next.onClick.RemoveListener(GoNext);
        Pervious.onClick.RemoveListener(GoPervious);
    }

    private void GoNext() => Value++;

    private void GoPervious() => Value--;
}
