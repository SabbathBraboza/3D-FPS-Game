using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
      [SerializeField] private Slider silder;
      [SerializeField] private TMP_Text text;

      private void Reset()
      {
            silder = GetComponentInChildren<Slider>();
            text = GetComponentInChildren<TMP_Text>();
      }

      private void OnEnable()
      {
            silder.onValueChanged.AddListener(UpdateText);
      }

      private void OnDisable()
      {
            silder.onValueChanged.RemoveListener(UpdateText);
      }

      private void UpdateText(float Value)
      {
            Value = Mathf.Clamp(Value * 100f ,min:0f, max:100f);

            text.text = Value.ToString("0.0") +"%";
      }
}
