using UnityEngine;
using Cinemachine;

namespace TPS.Player
{
    public class AimState : MonoBehaviour
    {
        public Cinemachine.AxisState xAxis, yAixs;
        [SerializeField] private Transform CameraFollow;

        private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;

        private void OnDisable() => Cursor.lockState = CursorLockMode.None;

        private void Update()
        {
            xAxis.Update(Time.deltaTime);
            yAixs.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            CameraFollow.localEulerAngles = new Vector3(yAixs.Value, CameraFollow.localEulerAngles.y, CameraFollow.localEulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
        }    
    }
}

