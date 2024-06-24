using Emp37.Utility;
using UnityEngine;

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

            [SerializeField, Readonly] private int Count;
            [SerializeField] private int MagazineSize;
            [SerializeField, Min(0.04f)] private float Rate = 0.1f;

            public float Firerate => Rate;
            public FireMode fireMode => Mode;

            private void Start()  => Count = MagazineSize;
          
            public void Fire()
            {
                  Count = Mathf.Clamp(Count - 1, 0, MagazineSize);
                  if (Count == 0) Reload();
            }
            public void Reload()
            {
                  Count = MagazineSize;  
            }
      }
}

