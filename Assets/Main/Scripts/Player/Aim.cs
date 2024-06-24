using Emp37.Utility;
using UnityEngine;

namespace FPS.Player
{ 
            [HideInInspector]
public class Aim : MonoBehaviour
      {
            [SerializeField, Readonly] private Vector2 position;
            public float Sensitivity;

            [Header("Input")]
            [SerializeField, Readonly] private Vector2 Mouse;

            [Space(5f)]
            [Header("References:")]
            [SerializeField] private new Transform transform;
            [SerializeField] private Transform Camera;

            #region Editor
            private void Reset()
            {
                  transform = base.transform;
                  Camera  = GetComponentInChildren<Camera>().transform;
            }
            #endregion

            private void Update()
            {
                  Mouse.Set(Input.GetAxis(KeyInput.MouseX), Input.GetAxis(KeyInput.MouseY));
                  if (Mouse.x != 0F || Mouse.y != 0F)
                  {
                        position.x = Mathf.Repeat(position.x + Mouse.x * Sensitivity, 360F);
                        position.y = Mathf.Clamp(position.y - Mouse.y * Sensitivity, -90F, 90F);

                        transform.localEulerAngles = new(0F, position.x);
                        Camera.localEulerAngles = new(position.y, 0F);
                  }
            }

      }

}
