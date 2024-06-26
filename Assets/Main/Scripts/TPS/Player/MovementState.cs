using UnityEngine;

namespace TPS.Player
{
    public class MovementState : MonoBehaviour
    {

        private Vector3 dir;
       

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

        private bool IsGrounded => controller.isGrounded;

        private void Reset() => controller = GetComponent<CharacterController>();
       
        private void Update()
        {
            Force.y = IsGrounded ? -Mass : Force.y + GravityScale * Gravity * Time.deltaTime;
            GetDirectionMove();
        }

        private void GetDirectionMove()
        {
            float HIput, VInput;
            HIput = Input.GetAxis("Horizontal");
            VInput = Input.GetAxis("Vertical");

            dir = transform.forward * VInput + transform.right * HIput;
            Vector3 move = (Force + dir) * Speed * Time.deltaTime;
            controller.Move(move);
        }
    }
}
