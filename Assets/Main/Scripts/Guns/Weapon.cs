using System.ComponentModel;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public abstract class Weapon : MonoBehaviour
{
      [Header("References:")]
      [SerializeField] private Animator anime;

      protected virtual void OnEnable()
      {
            gameObject.SetActive(true);
      }
      protected virtual void OnDisable()
      {
            anime.SetTrigger("DeEquip");
      }








      [Space(5f)]
      [Header("Weapon Mode and Type:")]
      [SerializeField] private WeaponType type;
      [SerializeField] private WeaponMode mode;

      [Space(5f)]
      [Header("Ammo:")]
      [SerializeField] private int Count;
      [SerializeField, Min(0)] private int ammo;
      [SerializeField, Min(0)] private int MagazineSize;

      [Space(5f)]
      [Header("FireRate:")]
      [SerializeField, Min(0.05f)] private float rate;
      [SerializeField] private float elapsed;

      private void Reset() => anime = GetComponent<Animator>();

      private void Update()
      {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                  elapsed = rate;
            }
            else
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                  anime.ResetTrigger("IsShoot");
            }

            if( mode == WeaponMode.Automatic && Input.GetKeyDown(KeyCode.Mouse0))
            {
             if (elapsed >= rate)
            {
                 Shoot();
                 elapsed = 0F;
             }
            else
                 elapsed += Time.deltaTime;
              
            }
      }
      public virtual void Shoot()
      {
            if (Count == 0) return;
            if((Count = Mathf.Clamp(Count -1 ,0,MagazineSize)) is 0)
            {
                  Reload();
            }
            anime.SetTrigger("IsShoot");
      }

      private void Reload()
      {

      }
            
}

