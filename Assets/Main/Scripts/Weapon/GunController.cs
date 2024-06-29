using Emp37.Utility;
using UnityEngine;

namespace FPS.Weapon
{
 public class GunController : MonoBehaviour
      {
        public Gun _equipped;

        [SerializeField] private Gun Primary, Secondary , Melee;
        [SerializeField, Readonly] private float elapsed;
        [SerializeField,Readonly(true)] private WeaponType equippedweaponType;

        private Gun Equipped => equippedweaponType switch
        {
            WeaponType.Primary => Primary,
            WeaponType.Secondary => Secondary,
            WeaponType.Melee => Melee,
            _=> null
        };

        private void Start() =>  Switch(equippedweaponType);   
        
        private void Update()
            {
                switch(Equipped.fireMode)
                  {
                        case Gun.FireMode.Semi:
                              {
                                    if (elapsed > 0f) elapsed = Mathf.Clamp01(elapsed - Time.deltaTime);
                                    if(Input.GetButtonDown(KeyInput.Fire) && elapsed == 0f)
                                    {
                                          Equipped.Fire();
                                          elapsed = Equipped.Firerate;
                                    }
                              }
                              break;
                        case Gun.FireMode.Automatic:
                              {
                                    if(Input.GetButtonDown(KeyInput.Fire))
                                    {
                                          elapsed = Equipped.Firerate;
                                    }
                                    if(Input.GetButton(KeyInput.Fire))
                                    {
                                          elapsed += Time.deltaTime;
                                          if(elapsed > Equipped.Firerate)
                                          {
                                                Equipped.Fire();
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
      }
}
