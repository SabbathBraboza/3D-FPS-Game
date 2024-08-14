using Emp37.Utility;
using TPS.Player;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace FPS.Weapon
{
 public class GunController : MonoBehaviour
      {
        private static readonly Vector2 Center = new Vector3(0.5f, 0.5f, 0);

        [field:SerializeField] public new Camera camera { get; private set;}
        [SerializeField] private Gun Primary, Secondary , MainGun;
        [SerializeField, Readonly] private float elapsed;
        [SerializeField,Readonly(true)] private WeaponType equippedweaponType;

        public Gun Equipped => equippedweaponType switch
        {
            WeaponType.Primary => Primary,
            WeaponType.Secondary => Secondary,
            WeaponType.Melee => MainGun,
            _=> null
        };

           // [Title("Events:")]
          
        private void Start() =>  Switch(equippedweaponType);

            private void Reset()
            {
                  camera = GetComponentInParent<Camera>();
            }

            private void Update()
            {
                switch(Equipped.Mode)
                  {
                        case Gun.FireMode.Semi:
                              {
                                    if (elapsed > 0f) elapsed = Mathf.Clamp01(elapsed - Time.deltaTime);
                                    if(Input.GetButtonDown(KeyInput.Fire) && elapsed == 0f)
                                    {
                                          Shoot();
                                          elapsed = Equipped.FireRate;
                                    }
                              }
                              break;
                        case Gun.FireMode.Automatic:
                              {
                                    if(Input.GetButtonDown(KeyInput.Fire))
                                    {
                                          elapsed = Equipped.FireRate;
                                    }
                                    if(Input.GetButton(KeyInput.Fire))
                                    {
                                          elapsed += Time.deltaTime;
                                          if(elapsed > Equipped.FireRate)
                                          {
                                                Shoot();
                                                elapsed = 0f;
                                          }
                                    }
                                    if(Input.GetButtonUp(KeyInput.Fire))
                                        elapsed = 0f;    
                              }
                              break;
                  }
                  if(Input.GetButtonDown(KeyInput.Reload))  Equipped.Reload();

            // // Handle weapon switching via number keys
            if (Input.GetKeyDown(KeyCode.Alpha1))
                  Switch(WeaponType.Primary);
            
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                   Switch(WeaponType.Secondary);

            else if (Input.GetKeyDown(KeyCode.Alpha3))
                       Switch(WeaponType.Melee);

            // Handle weapon switching via mouse scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0f)
            {
                if (scroll > 0f)
                {
                    // Scroll up, switch to the next weapon
                    if (equippedweaponType == WeaponType.Primary)
                        Switch(WeaponType.Secondary);
                    else if (equippedweaponType == WeaponType.Secondary)
                        Switch(WeaponType.Melee);
                    else
                        Switch(WeaponType.Primary);
                   Equipped.Muzzle.Stop();
                }
                else
                {
                    // Scroll down, switch to the previous weapon
                    if (equippedweaponType == WeaponType.Primary)
                        Switch(WeaponType.Melee);
                    else if (equippedweaponType == WeaponType.Secondary)
                        Switch(WeaponType.Primary);
                    else
                        Switch(WeaponType.Secondary);
                    Equipped.Muzzle.Stop();
                }
            }
        }
        public void Switch(WeaponType type) 
        { 
            switch(equippedweaponType = type)
            {
                case WeaponType.Primary:
                    {
                        Primary.gameObject.SetActive(true);
                        Secondary.gameObject.SetActive(false);
                        MainGun.gameObject.SetActive(false);
                    }
                    break;
                    case WeaponType.Secondary:
                    {
                        Primary.gameObject.SetActive(false);
                        Secondary.gameObject.SetActive(true);
                        MainGun.gameObject.SetActive(false);
                    }
                    break; 
                    case WeaponType.Melee:
                    {
                        Primary.gameObject.SetActive(false);
                        Secondary.gameObject.SetActive(false);
                        MainGun.gameObject.SetActive(true);
                    }
                    break;
                }
        }

            public void Shoot()
            {
                  Equipped.Fire();
                  Ray ray = camera.ViewportPointToRay(Center);
                  if(Physics.Raycast(ray,out RaycastHit info ,camera.farClipPlane))
                  {
                        if(info.collider != null && info.collider.TryGetComponent(out IDamge ID))
                        {
                            ID.Damage(Equipped.Damage);

                        }
                  }
            }
      }
}
