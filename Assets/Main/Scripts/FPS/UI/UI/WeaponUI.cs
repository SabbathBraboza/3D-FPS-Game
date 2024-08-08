using FPS.Weapon;
using TMPro;
using UnityEngine;

namespace FPS.UI.Weapon
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField] private Gun gun;
        [SerializeField] private TMP_Text GunAmmo;

        private void Reset()
        {
            gun = GetComponentInParent<Gun>();  
        }

        private void OnEnable()
        {
            gun.OnFire.AddListener(_ => UpdateAmmo());
            gun.OnRefill.AddListener(UpdateAmmo);
            gun.OnReload.AddListener(UpdateAmmo);
        }

        public void UpdateAmmo() => GunAmmo.text = $"{gun.Current}/{gun.MagazineSize}";
    }
}
