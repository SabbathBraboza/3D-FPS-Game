using Emp37.Utility;
using UnityEngine;

namespace FPS.Weapon
{
      public class GunController : MonoBehaviour
      {
            [SerializeField] private Gun equipped;

            [SerializeField, Readonly] private float elapsed;

            private void Update()
            {
                  if(Input.GetButtonDown(KeyInput.Fire)) { 
                        equipped.Fire();
                  }
                  if(equipped.fireMode == Gun.FireMode.Automatic && Input.GetButton(KeyInput.Fire)) {
                        elapsed += Time.deltaTime;
                        if(elapsed  > equipped.Firerate)
                        {
                              equipped.Fire();
                              elapsed = 0f;
                        }
                  }
                  if(Input.GetButtonUp(KeyInput.Fire))
                  {
                        elapsed = 0f;
                  }
                  if(Input.GetButtonDown(KeyInput.Reload))
                  {
                        equipped.Reload();
                  }
            }
      }
}
