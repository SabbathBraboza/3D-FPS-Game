using UnityEngine;
using System;

public class CodeScreen : MonoBehaviour, IInteractable
{
      [SerializeField] private InteractiveScreen screen;
      [SerializeField] private int pass;
      [SerializeField] private bool WasEnteredCorrectly;


      private void Update()
      {
            if (WasEnteredCorrectly) return;

            if(Input.anyKeyDown)
            {
                  foreach(KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                  {
                        if(Input.GetKeyDown(keycode))
                        {
                              if(keycode >= KeyCode.Alpha0 && keycode <= KeyCode.Alpha9)
                              {
                                    screen.Write((char)( keycode - KeyCode.Alpha0 + '0'));
                              }
                              else if (keycode >= KeyCode.Keypad0 && keycode <= KeyCode.Keypad9)
                              {
                                    screen.Write((char)(keycode - KeyCode.Keypad0 + '0'));
                              }
                              else if (keycode == KeyCode.Backspace)
                              {
                                    screen.Remove();
                                    return;
                              }
                        }
                        if(screen.Check(pass))
                        {
                              WasEnteredCorrectly = true;
                              enabled = false;
                        }
                  }
            }
      }

      public void OnEnter()
      {
            if (WasEnteredCorrectly) return;
            enabled = true;
            screen.Clear();
      }

      public void OnExit()
      {
            enabled = false;
      }

      public void OnInteract()
      { 
      }
}
