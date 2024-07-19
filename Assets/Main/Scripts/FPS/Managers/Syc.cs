using UnityEngine;

public class Syc : MonoBehaviour
{
      [SerializeField] private Behaviour[] syc;

      protected virtual void OnEnable()
      {
            foreach (var behaviour in syc) behaviour.enabled = true;
      }

      protected virtual void OnDisable()
      {
            foreach (var behaviour in syc) behaviour.enabled = false;
      }
}