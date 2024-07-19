using Emp37.Utility;
using UnityEngine;

namespace FPS.Player
{
      [HideInInspector]
      public class Player : MonoBehaviour
      {
            [Header("References:")]
            [SerializeField] private CharacterController Controller;
            [SerializeField] private Transform Camera;
            [SerializeField] private Aim aim;
            [SerializeField] private Movement movement;

            [Space(5f)]
            [Header("Phyics:")]
            [Min(1f)] public float Mass = 1f;
            [Readonly] public Vector3 Force;
            [Min(0f)] public float GravityScale = 1f;
            private const float gravity = -9.81F;

            public bool IsGrounded => Controller.isGrounded;

            #region Editor

            private void Reset()
            {
                  Controller = GetComponent<CharacterController>();
                  Camera = GetComponentInChildren<Camera>().transform;
            }
            #endregion

            #region RunTime
            private void OnEnable()
            {
                  aim.enabled = true;
                  Cursor.lockState = CursorLockMode.Locked;
            }
            private void Update()
            {
                  Force.y = IsGrounded ? -Mass : Force.y + GravityScale * gravity * Time.deltaTime;

                  if (Input.GetButtonDown(KeyInput.Horizontal) || Input.GetButtonDown(KeyInput.Vertical))
                  {
                        movement.enabled = true;
                  }
                  Controller.Move((Force + movement.Pace) * Time.deltaTime);
            }
            private void OnDisable()
            {
                  Cursor.lockState = CursorLockMode.None;
                  aim.enabled = false;
            }
            #endregion
      }

     }

