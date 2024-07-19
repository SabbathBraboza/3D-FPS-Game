using Emp37.Utility;
using UnityEngine;

namespace FPS.Player
{
      [HideInInspector]
      public class Movement : MonoBehaviour
      {
            [SerializeField, Readonly] private Vector3 pace, damping;
            [SerializeField] private float maximumDamping, smoothness;
            public float WalkPace = 2F, RunPace = 6F;

            [Header("Input")]
            [SerializeField, Readonly] private Vector3 KeyBoard;

            public Vector3 Pace => pace;

            private void Update()
            {
                  KeyBoard.Set(Input.GetAxisRaw(KeyInput.Horizontal), 0f, Input.GetAxisRaw(KeyInput.Vertical));
                  if( KeyBoard.x !=0f || KeyBoard.z !=0f || pace != Vector3.zero )
                  {
                        var Pace  = Input.GetButton(KeyInput.Walk) ? WalkPace : RunPace;
                        var target = Pace * transform.TransformDirection(KeyBoard.normalized);
                        pace = Vector3.SmoothDamp(pace, target, ref damping, smoothness, maximumDamping, Time.deltaTime);
                  }
                  else
                  {
                        enabled = false;
                  }
            }
            private void OnDisable() =>pace = damping = Vector3.zero;
       }
}
