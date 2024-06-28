using UnityEngine;


namespace FPS.Weapon.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class GunAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource source;


        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }
    }
}
