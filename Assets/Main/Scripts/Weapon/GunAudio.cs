using UnityEngine;


namespace FPS.Weapon.Audio
{
    public class GunAudio : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Gun gun;
        [SerializeField] private AudioSource source;

        [Space(5f)]
        [Header("Cilps:")]
        [SerializeField] private AudioClip Shoot;
        [SerializeField] private AudioClip[] ReloadSquence;

        private void Awake()
        {
            source = GetComponentInParent<AudioSource>();
            gun = GetComponent<Gun>();
        }

        private void OnEnable()
        {
            gun.OnFire.AddListener(PlayShoot);
        }

        private void OnDisable()
        {
            gun.OnFire.RemoveListener(PlayShoot);
        }

        public void PlayShoot(float progress)
        {
           source.PlayOneShot(Shoot);
        }

        private void PlayReload(int index)
        {
            source.PlayOneShot(ReloadSquence[index]);
        }
    }
}
