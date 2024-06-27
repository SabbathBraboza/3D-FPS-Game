using Emp37.Utility;
using UnityEngine;

namespace TPS.Player
{
    public class MovementState : MonoBehaviour
    {
       [SerializeField,Readonly] public Vector3 dir;
       [SerializeField,Readonly] public float HInput, VInput;

        [Header("Values:")]
        public float CurrentMoveSpeed = 3;
        public float WalkSpeed = 3, WalkBackSpeed = 2;
        public float RunSpeed = 6, RunBackSpeed = 3;



        [Space(5f)]
        [Header("References:")]
        [SerializeField] private CharacterController controller;
        public Animator anime;

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

        private void Reset()
        {
            controller = GetComponent<CharacterController>();
            anime = GetComponent<Animator>();
        }
        private void Start()
        {
            SwitchState(idle);
        }

        private void Update()
        {
            Force.y = IsGrounded ? -Mass : Force.y + GravityScale * Gravity * Time.deltaTime;
            GetDirectionMove();

            anime.SetFloat("hInput",HInput);
            anime.SetFloat("vInput",VInput);

            CurrentState.UpdateState(this);
        }

        public void SwitchState(MovementBaseState State)
        {
            CurrentState = State;
            CurrentState.EnterState(this); 
        }

        public void GetDirectionMove()
        {
            HInput = Input.GetAxis("Horizontal");
            VInput = Input.GetAxis("Vertical");

            dir = transform.forward * VInput + transform.right * HInput;
            Vector3 move = (Force + dir.normalized) * CurrentMoveSpeed * Time.deltaTime;
            controller.Move(move);
        }
    }
}
