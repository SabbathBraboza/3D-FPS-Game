using UnityEngine;

namespace FPS.Player
{
    [HideInInspector]
    public class Play : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private CharacterController Controller;
        [SerializeField] private Transform Camera;


        private void Reset()
        {
            Controller = GetComponent<CharacterController>();
            Camera = GetComponentInChildren<Camera>().transform;
        }

        private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;
        private void OnDisable() => Cursor.lockState = CursorLockMode.None;

        private void Update()
        {
            
        }

    }
}
