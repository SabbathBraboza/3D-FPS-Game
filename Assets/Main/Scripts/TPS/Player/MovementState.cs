using Emp37.Utility;
using UnityEngine;

namespace TPS.Player
{
    public class MovementState : MonoBehaviour
    {
       [SerializeField,Readonly] public Vector3 dir;
  
        [Header("Values:")]
        [SerializeField] private float Speed;
        
        [Space(5f)]
        [Header("References:")]
        [SerializeField] private CharacterController controller;

        [Space(5f)]
        [Header("Phyics:")]
        [Min(1f)] public float Mass = 1f;
        private Vector3 Force;
        [Min(0f)] public float GravityScale = 1f;
        private const float Gravity = -9.81F;

        private MovementBaseState CurrentState;

        public IdleState idle = new IdleState(); 
        public WalkState Walk = new WalkState();
        public RunState Run = new RunState(); 
 
        private bool IsGrounded => controller.isGrounded;
        
        private void Reset() => controller = GetComponent<CharacterController>();
   
        private void Start()
        {
            SwitchState(idle);
        }

        private void Update()
        {
            Force.y = IsGrounded ? -Mass : Force.y + GravityScale * Gravity * Time.deltaTime;
            GetDirectionMove();

            CurrentState.UpdateState(this);
        }

        public void SwitchState(MovementBaseState State)
        {
            CurrentState = State;
            CurrentState.EnterState(this); 

        }

        private void GetDirectionMove()
        {
            float HIput, VInput;
            HIput = Input.GetAxis("Horizontal");
            VInput = Input.GetAxis("Vertical");

            dir = transform.forward * VInput + transform.right * HIput;
            Vector3 move = (Force + dir.normalized) * Speed * Time.deltaTime;
            controller.Move(move);
        }
    }
}
