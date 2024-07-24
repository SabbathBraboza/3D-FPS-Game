using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
   public enum Type
      {  
            Manual,
            Proximity,
            Interactive
      }

      private static readonly int OpenHash = Animator.StringToHash("Open");

      [SerializeField] private Type type;
      [SerializeField] private BoxCollider box;
      [SerializeField] private Animator anime;

      public Type ManageType
      {
            get => type;
            set
            {
                  switch (type)
                  {
                        case Type.Manual:
                              box.enabled = false;
                              break;

                         case Type.Interactive or Type.Proximity:
                              box.enabled = true;    
                              break;
                  }
            }
      }

      [SerializeField] private bool locked = true;

      private void Reset()
      {
            box = GetComponent<BoxCollider>();
            anime = GetComponent<Animator>();
      }

      private void OnValidate()
      {
            ManageType = type;
      }

      public void OnEnter()
      {
            if (type != Type.Proximity || locked) return;
            anime.SetBool(OpenHash, true);
      }

      public void OnExit()
      {
            if(type != Type.Proximity || locked) return;
            anime.SetBool(OpenHash, false);
      }

      public void OnInteract()
      {
            if (type != Type.Interactive || locked) return;
            anime.SetBool(OpenHash, !anime.GetBool(OpenHash));
      }

      public void Open(bool value)
      {
            if (type != Type.Manual) return;
            anime.SetBool(OpenHash, value);
      }

      public void Unlock() => locked = false;
}
