using Emp37.Utility;
using TMPro;
using UnityEngine;

public class InteractiveScreen : MonoBehaviour
{
      [SerializeField] private TMP_Text Input;
      [SerializeField] private Material BackgroundScreen;
      private bool IsFilled => Input.text.Length > 3;

      private readonly int colorhash = Shader.PropertyToID("_Color");
      private Shades SetColor { set => BackgroundScreen.SetColor(colorhash, ColorLibrary.Pick(value)); }

      public void Write(char value)
      {
            if(IsFilled)
            {
                  Clear();
                  return;
            }
            if(char.IsDigit(value))
            {
                  Input.text += value;
            }
      }

      public void Remove()
      {
            if(Input.text.Length > 0)
            {
                  Input.text = Input.text.Substring(0, Input.text.Length - 1);
                  SetColor = Shades.Blue;
            }
      }

      public bool Check(int password)
      {
            if (!IsFilled) return false;

            bool condition = Input.text == password.ToString();
            if (condition) SetColor = Shades.Green;
            return condition; 
      }

      public void Clear()
      {
            SetColor = Shades.Green;
            Input.text = string.Empty;
      }
}
