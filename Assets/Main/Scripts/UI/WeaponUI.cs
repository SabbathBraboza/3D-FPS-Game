using FPS.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace FPS.UI.Weapon
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private GunController Controller;
        [SerializeField] private TMP_Text GunAmmo;
        [SerializeField] private Image EqquipedGun;

        public void UpdateWeaponIcon()
        {
                  EqquipedGun.sprite = Controller.Equipped.Icon;
                  UpdateAmmo();
        }

            public void UpdateAmmo()
            {
                  var gun = Controller.Equipped;
                  GunAmmo.text = $"{gun.Current}/{gun.MagazineSize}";
            }
      }
}
