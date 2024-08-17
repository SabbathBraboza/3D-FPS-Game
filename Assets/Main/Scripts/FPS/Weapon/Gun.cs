using Emp37.Utility;
using UnityEngine;
using UnityEngine.Events;

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
        [field: SerializeField] public ParticleSystem Muzzle { get; private set; }

        public Transform Nozzle => _nozzle;

        [SerializeField] private Transform ShellEjectionPoint;
        [SerializeField] private GameObject ShellPrefab;


        [Header("Values:")]
        [SerializeField, Readonly] private int reserved;
        [field: SerializeField] public int MagazineSize { get; private set; }
        [field: SerializeField] public FireMode Mode { get; private set; }
        [SerializeField] public int Total { get; private set; } = 50;
        [field: SerializeField, Min(0.04f)] public float FireRate { get; private set; } = 0.1f;
        [field: SerializeField] public int Damage { get; private set; }

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

        private void Start() => Refill();

        [Button]
        private void Reset() => _nozzle = transform.Find("Nozzle");
        
        public void Fire()
        {
            if (Current == 0)
            {
                Reload();
                return;
            }
            Muzzle.Play();
            Current--; 
            OnFire.Invoke(Extensions.Remap(Current, 0f, MagazineSize, 0f, 1f));
        }

        public void Reload()
        {
            Muzzle.Stop();
            if (Current == MagazineSize || Total == 0)
            {
                return;
            }
            reserved = MagazineSize - Current;
            Current = 0;

            OnReload.Invoke();
        }

        public void Refill()
        {
            Muzzle.Stop();
            Current = Total;
            reserved = 0;
        }

        public void SpawnAndEjectShell()
        {
            if (ShellPrefab != null && ShellEjectionPoint != null)
            {
                var shell = Instantiate(ShellPrefab, ShellEjectionPoint.position, ShellEjectionPoint.rotation);
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                if (shellRb != null)
                {
                    // Generate a random direction with slight variations
                    Vector3 randomDirection = ShellEjectionPoint.right + new Vector3(
                        Random.Range(-0.08f, 0.08f), // Random variation in x direction
                        Random.Range(-0.02f, 0.08f), // Random variation in y direction
                        Random.Range(-0.08f, 0.08f)  // Random variation in z direction
                    ).normalized;

                    // Apply random torque to simulate spinning effect
                    Vector3 randomTorque = new Vector3(
                        Random.Range(-20.0f, 20.0f), // Random torque around x-axis
                        Random.Range(-20.0f, 20.0f), // Random torque around y-axis
                        Random.Range(-20.0f, 20.0f)  // Random torque around z-axis
                    );

                    // Apply torque and force with randomness
                    shellRb.AddTorque(randomTorque, ForceMode.Impulse);

                    float randomForce = Random.Range(4.0f, 5.0f); // Random force between 4 and 5
                    shellRb.AddForce(randomDirection * randomForce, ForceMode.Impulse);
                }
            }
        }

      
    }
}


