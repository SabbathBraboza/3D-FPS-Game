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
                switch(equipped.fireMode)
                  {
                        case Gun.FireMode.Semi:
                              {
                                    if (elapsed > 0f) elapsed = Mathf.Clamp01(elapsed - Time.deltaTime);
                                    if(Input.GetButtonDown(KeyInput.Fire) && elapsed == 0f)
                                    {
                                          equipped.Fire();
                                          elapsed = equipped.Firerate;
                                    }
                              }
                              break;
                        case Gun.FireMode.Automatic:
                              {
                                    if(Input.GetButtonDown(KeyInput.Fire))
                                    {
                                          elapsed = equipped.Firerate;
                                    }
                                    if(Input.GetButton(KeyInput.Fire))
                                    {
                                          elapsed += Time.deltaTime;
                                          if(elapsed > equipped.Firerate)
                                          {
                                                equipped.Fire();
                                                elapsed = 0f;
                                          }
                                    }
                                    if(Input.GetButtonUp(KeyInput.Fire))
                                    {
                                          elapsed = 0f;
                                    }
                              }
                              break;
                  }
                  if(Input.GetButtonDown(KeyInput.Reload))
                  {
                        equipped.Reload();
                        print("Reloading");
                  }
            }
      }
}
