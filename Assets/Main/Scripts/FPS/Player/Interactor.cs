using UnityEngine;

public class Interactor : MonoBehaviour
{
      public KeyCode InteractKey = KeyCode.T;
      private IInteractable interactable;
      public bool IsInside => interactable != null;

      private void OnTriggerEnter(Collider other)
      {
            if (other.TryGetComponent(out interactable))
            {
                  interactable.OnEnter();
                  enabled = true;
            }
      }
            private void LateUpdate()
            {
                  if (IsInside && Input.GetKeyDown(InteractKey))
                  {
                        interactable.OnInteract();
                  }
            }
            private void OnTriggerExit(Collider other)
            {
                  if (other.TryGetComponent(out IInteractable II) && interactable == II)
                  {
                        interactable.OnExit();
                        interactable = null;

                        enabled = false;
                  }
           }
  }       

