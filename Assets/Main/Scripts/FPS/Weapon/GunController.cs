using Emp37.Utility;
using TPS.Player;
using UnityEngine;

namespace FPS.Weapon
{
 public class GunController : MonoBehaviour
      {
        private static readonly Vector2 Center = new Vector3(0.5f, 0.5f, 0);

        [SerializeField] private new Camera camera;
        [SerializeField] private Gun Primary, Secondary , Melee;
        [SerializeField, Readonly] private float elapsed;
        [SerializeField,Readonly(true)] private WeaponType equippedweaponType;

        public Gun Equipped => equippedweaponType switch
        {
            WeaponType.Primary => Primary,
            WeaponType.Secondary => Secondary,
            WeaponType.Melee => Melee,
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

            if (Input.GetKeyDown(KeyCode.Alpha1))
                  Switch(WeaponType.Primary);
            
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                   Switch(WeaponType.Secondary);

            else if (Input.GetKeyDown(KeyCode.Alpha3))
                       Switch(WeaponType.Melee);
        }
        public void Switch(WeaponType type) 
        { 
            switch(equippedweaponType = type)
            {
                case WeaponType.Primary:
                    {
                        Primary.gameObject.SetActive(true);
                        Secondary.gameObject.SetActive(false);
                        Melee.gameObject.SetActive(false);
                    }
                    break;
                    case WeaponType.Secondary:
                    {
                        Primary.gameObject.SetActive(false);
                        Secondary.gameObject.SetActive(true);
                        Melee.gameObject.SetActive(false);
                    }
                    break; 
                    case WeaponType.Melee:
                    {
                        Primary.gameObject.SetActive(false);
                        Secondary.gameObject.SetActive(false);
                        Melee.gameObject.SetActive(true);
                    }
                    break;
                }
        }

            private void Shoot()
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
