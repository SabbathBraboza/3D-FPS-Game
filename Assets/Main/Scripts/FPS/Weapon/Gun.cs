using Emp37.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

namespace FPS.Weapon
{
      public class Gun : MonoBehaviour
      {
            public enum FireMode
            {
                  Semi,
                  Automatic,
            }

            [Header("Reference:")]
            [SerializeField] private Transform _nozzle;
            public Transform Nozzle => _nozzle;

            [SerializeField] private GameObject MuzzleFlash;
            [SerializeField] private VisualEffect visualEffect;

            [Header("Values:")]
            [SerializeField, Readonly] private int reserved;
            [field:SerializeField] public int MagazineSize { get; private set; }
            [field:SerializeField] public FireMode Mode { get; private set; }
            [SerializeField] public int Total { get; private set; } = 50;
            [field: SerializeField, Min(0.04f)] public float FireRate { get; private set; } = 0.1f;
            [field:SerializeField] public int Damage { get; private set; }

            [SerializeField, Readonly] private int _current; public int Current
            {
                  get => _current;
                  set
                  {
                        _current = Mathf.Clamp(value, 0, MagazineSize);
                  }
            }

            [Space(10f)]
            [Header("Events:")]
            public UnityEvent<float> OnFire;
            public UnityEvent OnReload;
            public UnityEvent OnRefill;


        private void OnDestroy()
        {
            OnFire.RemoveAllListeners();
            OnReload.RemoveAllListeners();
            OnRefill.RemoveAllListeners();
        }

        private void Start()
            {
                  Refill();
                  visualEffect = MuzzleFlash.GetComponent<VisualEffect>();
            }
            [Button]
            private void Reset()
            {
                  _nozzle = transform.Find("Nozzle");
            }

        public void Fire()
            {
                  if (Current == 0)
                  {
                        Reload();
                        return;
                  }
                  Current--;
                  OnFire.Invoke(Extensions.Remap(Current,0f,MagazineSize,0f,1f));
                  PlayEffects();
                      
            }
            public void Reload()
            {
                  if(Current == MagazineSize ||Total == 0 )
                  {
                        return;
                  }
                  reserved = MagazineSize - Current;
                  Current = 0;

                  OnReload.Invoke();
            }

            public void Refill()
            {
                  Current = Total;
                  reserved = 0;
            }

            private void PlayEffects()
            {
                
                  if (visualEffect != null &&visualEffect.isActiveAndEnabled)
                  {
                        visualEffect.Play(); // Play the VisualEffect
                        Debug.Log("Is Playing");
                  }
                  else
                  {
                        visualEffect.Stop(); // Stop the VisualEffect
                        Debug.Log("Stoppppped");
                  }
            }
      }
}

