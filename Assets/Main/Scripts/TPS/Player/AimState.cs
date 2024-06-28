using UnityEngine;
using Cinemachine;

namespace TPS.Player
{
    public class AimState : MonoBehaviour
    {
        AimStateBase CurrentState;
        public AimIdleshoot idle = new AimIdleshoot();
        public AimShoot shoot = new AimShoot();

        [Header("References:")]
        public Cinemachine.AxisState xAxis, yAixs;
        [SerializeField] private Transform CameraFollow;
        [SerializeField] public Animator anime;
        [SerializeField] public CinemachineVirtualCamera cam;

        [Space(5f)]
        [Header("Values:")]
        public float adsfov = 40;
        public float HipFov;
        public float CurrentFov;
        public float FovSmoothSpeed;
        

        private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;

        private void OnDisable() => Cursor.lockState = CursorLockMode.None;

        private void Awake()
        {
            anime = GetComponent<Animator>();
            cam = GetComponentInChildren<CinemachineVirtualCamera>();
            HipFov = cam.m_Lens.FieldOfView; 
        }
        private void Start() => SwitchState(idle);
        
        private void Update()
        {
            xAxis.Update(Time.deltaTime);
            yAixs.Update(Time.deltaTime);

            cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, CurrentFov,FovSmoothSpeed* Time.deltaTime);
            
            CurrentState.UpdateState(this);
        }

        private void LateUpdate()
        {
            CameraFollow.localEulerAngles = new Vector3(yAixs.Value, CameraFollow.localEulerAngles.y, CameraFollow.localEulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
        }
        
        public void SwitchState(AimStateBase state)
        {
            CurrentState = state;
            CurrentState.EnterState(this);
        }
    }
}

