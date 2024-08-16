using UnityEngine;
using System;
using UnityEngine.Events;


public class CodeScreen : MonoBehaviour, IInteractable
{
      [SerializeField] private InteractiveScreen screen;
      
      [SerializeField] private int pass;

     [SerializeField] private new  MeshRenderer renderer;

      [SerializeField] private bool WasEnteredCorrectly;

      public UnityEvent OnUnlock;

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
                        if (screen.Check(pass))
                        {
                              WasEnteredCorrectly = true;
                              OnUnlock.Invoke();
                              Material newMaterial = Resources.Load<Material>("Materials/Unlock");
                              if (newMaterial != null)
                              {
                                    if (renderer != null && renderer.materials.Length > 0)
                                          renderer.materials[0] = newMaterial;
                              }
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
