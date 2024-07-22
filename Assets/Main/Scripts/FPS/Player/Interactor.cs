using UnityEngine;

public class Interactor : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
      {
            if(other.TryGetComponent(out IInteractable IN))
            {
                  IN.OnEnter();
            }
      }

      private void OnTriggerExit(Collider other)
      {
            if (other.TryGetComponent(out IInteractable IN))
            {
                  IN.OnExit();
            }
      }
}
