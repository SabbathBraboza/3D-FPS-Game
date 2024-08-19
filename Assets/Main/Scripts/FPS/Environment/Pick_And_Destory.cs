using UnityEngine;
using UnityEngine.Events;

public class Pick_And_Destory : MonoBehaviour,IInteractable
{
    [Header("UI:")]
    [SerializeField] private GameObject text;

    [Header("Audio:")]
    [SerializeField] private AudioClip Voice;
    [SerializeField] private AudioSource source;

     [Header("Unity Event:")]
     public UnityEvent Active;
    
      public void OnInteract()
      {
            if (Input.GetKeyDown(KeyCode.P))
            {
                  text.SetActive(false);
                  source.PlayOneShot(Voice);
                  Destroy(gameObject);

                   Active.Invoke();
           }
      }

      private void Update()
      {
            OnInteract();
      }

      public void OnEnter()
      {
         
      }

      public void OnExit()
      {
         
      }

}
