using UnityEngine;

public class Pick_And_Destory : MonoBehaviour,IInteractable
{
      [SerializeField] private GameObject text;

      [SerializeField] private AudioClip Voice;
      [SerializeField] private AudioSource source;

    [SerializeField] private GameObject Mission2;
    
      public void OnInteract()
      {
            if (Input.GetKeyDown(KeyCode.P))
            {
                  text.SetActive(false);
                  source.PlayOneShot(Voice);
                  Destroy(gameObject);

            if(Mission2 != null)
            {
                Mission2.SetActive(true);
            }
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
