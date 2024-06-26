using UnityEngine;


namespace FPS.Weapon
{
      using Utility;

      [RequireComponent(typeof(Gun))]
      public class GunAnimation : MonoBehaviour
      {
            [SerializeField] private Gun gun;
            [SerializeField] private Animator anime;

            private void Reset()
            {
                  gun =GetComponent<Gun>();
                  anime = GetComponent<Animator>();
            }

            private void OnEnable()
            {
                  gun.OnFire.AddListener(Onfire);
                  gun.OnReload.AddListener(Onreload);
            }
            private void OnDisable()
            {
                  gun.OnFire.RemoveListener(Onfire);
                  gun.OnReload.RemoveListener(Onreload);
            }

            private void Onfire(float Value)
            {
                  anime.SetTrigger(Hash.Shoot);
                  print(Value);
            }

            private void Onreload()
            {
                  anime.SetBool(Hash.Reload, true);
            }

      }  
}
