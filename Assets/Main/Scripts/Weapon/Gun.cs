using Emp37.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace FPS.Weapon
{
      public class Gun : MonoBehaviour
      {
            public enum FireMode
            {
                  Semi,
                  Automatic,
            }

            [SerializeField] private FireMode Mode;

            [SerializeField, Readonly] private int Current;
            [SerializeField] private int MagazineSize;
            [SerializeField] private int ammo = 30;
            [SerializeField, Min(0.04f)] private float Rate = 0.1f;
            [SerializeField, Readonly] private int reserved;

            [Space(10f)]
            [Header("Events:")]
            public UnityEvent<float> OnFire;
            public UnityEvent OnReload;

            public float Firerate => Rate;
            public FireMode fireMode => Mode;

            private void Start() => Refill();
          
            public void Fire()
            {
                  if (Current == 0)
                  {
                        Reload();
                        return;
                  }
                  Current = Mathf.Clamp(Current - 1, 0, MagazineSize);
                  OnFire.Invoke(Extensions.Remap(Current,0f,MagazineSize,0f,1f));
                      
            }
            public void Reload()
            {
                  if(Current == MagazineSize ||ammo == 0 )
                  {
                        return;
                  }
                  reserved = Mathf.Clamp(MagazineSize - Current, 0, ammo);
                  Current = 0;

                  OnReload.Invoke();
            }

            public void Refill()
            {
                  Current = MagazineSize;
                  reserved = 0;
            }
      }
}

