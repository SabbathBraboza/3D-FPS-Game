using Emp37.Utility;
using System.Runtime.InteropServices;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPS_Controller : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Animator Anime;

    [Title("VALUES", Shades.Crimson)]
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float Jump;
    [SerializeField] private float Gravity = 10f;

    
    private float WatchSpeed = 2f;
    private float LookXLimit = 45f;
    private float RotationX = 0;
    Vector3 MoveDirection = Vector3.zero;

    private bool CanMove = true;

    CharacterController characterController;
    private void Start()
    {
        Anime = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        #region Handles Movements
        Vector3 forword = transform.TransformDirection(Vector3.forward);
        Vector3 rigth = transform.TransformDirection(Vector3.right);

        // Press Left Shift to Run
        bool IsRunning = Input.GetKey(KeyCode.LeftShift);
        float CurSpeedx = CanMove ? (IsRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Vertical") : 0;
        float CurSpeedy = CanMove ? (IsRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Horizontal") : 0;
        float MovementDirectionY = MoveDirection.y;
        MoveDirection= (forword * CurSpeedx) +(rigth * CurSpeedy);
        #endregion

        #region Handles Jumping
        if(Input.GetKeyDown(KeyCode.Space) && CanMove && characterController.isGrounded) MoveDirection.y = Jump;
        
        else MoveDirection.y = MovementDirectionY;
        
        if(!characterController.isGrounded) MoveDirection.y -= Gravity * Time.deltaTime;
        #endregion

        #region Handles Rotation
        characterController.Move(MoveDirection * Time.deltaTime);

        if(CanMove)
        {
            RotationX += -Input.GetAxis("Mouse Y") * WatchSpeed;
            RotationX = Mathf.Clamp(RotationX, -LookXLimit, LookXLimit);
            PlayerCamera.transform.localRotation = Quaternion.Euler(RotationX, 0,0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * WatchSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Anime.SetTrigger("IsShoot");

        if (Input.GetKeyDown(KeyCode.R))
            Anime.SetTrigger("IsReload");

        if (Input.GetKeyDown(KeyCode.Y))
            Anime.SetTrigger("IsWatch");



        #endregion
    }
}
