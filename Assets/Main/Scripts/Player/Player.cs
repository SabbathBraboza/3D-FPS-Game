using Emp37.Utility;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("_____________GameObjects:____________")]
    [SerializeField] private new Transform transform;
    [SerializeField] private Transform Playercamera;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private GameObject Sheriff;
    [SerializeField] private GameObject M46;

     [Space(5f)]
    [Header("________________Phyics:_____________")]
    [SerializeField] private float gavityScale = 1f;
    [SerializeField, Readonly] private Vector3 Force;
    [Min(0)] public float mass = 10f;

      [Space(5f)]
      [Header("______________Movements:____________")]
    [SerializeField, Readonly] private Vector3 Movement;
    [SerializeField, Readonly] private float Smoothness = 0.3f;
    [SerializeField]private float WalkPace = 4f, NormalPace = 8f;
    [SerializeField] private float JumpHeigth =10f;
    [SerializeField, Readonly] private float maxDamping = 75f;
    [SerializeField, Readonly] private Vector3 damping;

      [Space(5f)]
      [Header("______________Aiming:___________")]
    public Vector2 Senitivity = Vector2.one;
    [SerializeField, Readonly] private Vector2 rotation;
    [SerializeField, Readonly] private float minPitch = -90f, maxPitch = 90f;
    [SerializeField, Readonly] private bool Invert;

      [Space(5f)]
      [Header("_____________Inputs:________________")]
    [SerializeField, Readonly] private Vector3 Keyborad;
    [SerializeField, Readonly] private Vector2 Mouse;

      [Space(5f)]
      [Header("___________Crouching:_____________")]
    [SerializeField] private bool _isCrouching;
    [SerializeField] private float CrouchHieght , CrouchSpeed , targetCrouchHeight;
    [SerializeField] private Vector3 CrouchCenter;
    private float intialHeight;
    private Vector3 intialCenter, TargetCenter;

    public bool IsCrouching
    {
        get => _isCrouching;
         private set
        {
            _isCrouching = value;

            targetCrouchHeight = _isCrouching ? CrouchHieght: intialHeight;
            TargetCenter = _isCrouching ?CrouchCenter: intialCenter;
        }
    }
    private Animator anime;
    public bool IsKeyboradActive => Keyborad.x != 0f || Keyborad.z != 0f;
    public bool IsMouseActive => Mouse.x != 0f || Mouse.y != 0f; 
    public bool IsGrounded => Controller.isGrounded;
    public bool IsMoving => IsKeyboradActive || Movement != Vector3.zero;

    private void Awake() =>anime = GetComponentInChildren<Animator>();
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        targetCrouchHeight = intialHeight = Controller.height;
        TargetCenter = intialCenter = Controller.center;
        TargetCenter = intialCenter = Controller.center;
    }
    private void Update()
    {
        Force = Controller.isGrounded ? mass * Physics.gravity.normalized : Force + gavityScale * Time.deltaTime * Physics.gravity;

        #region Aiming
        Mouse.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if(IsMouseActive)
        {
            rotation.x = Mathf.Repeat(rotation.x + Mouse.x * Senitivity.x, 360f);
            transform.localEulerAngles = new Vector2(x:0f,y:rotation.x);

            rotation.y = Mathf.Clamp(rotation.y - Mouse.y * Senitivity.y, minPitch,maxPitch);
            Playercamera.localEulerAngles = new Vector3(x: rotation.y * (Invert ? -1f : 1f), y:0f) ;
        }
        #endregion

        #region Movement
        Keyborad.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if(IsMoving) 
        { 
        
          float pace  = Input.GetKey(KeyCode.LeftShift) ? WalkPace : NormalPace;
            Vector3 target = pace * transform.TransformDirection(Keyborad.normalized);

            Movement = Vector3.SmoothDamp(Movement, target, ref damping, Smoothness, maxDamping);
        }
        else Movement  =damping =Vector3.zero;
        
        Controller.Move(Time.deltaTime * (Movement + Force));
            #endregion

        #region Jumping And Crouching
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) Jump(JumpHeigth);  
            Controller.Move(Time.deltaTime * (Movement + Force));

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsCrouching = !IsCrouching;
        }
        if(Controller.height != targetCrouchHeight || Controller.center != TargetCenter)
        {
            Controller.height = Mathf.Lerp(Controller.height, targetCrouchHeight, CrouchSpeed* Time.deltaTime);
            Controller.center = Vector3.Lerp(Controller.center, TargetCenter, CrouchSpeed * Time.deltaTime);
        }
            #endregion

         #region Animation
            if (Input.GetKeyDown(KeyCode.Y)) anime.SetTrigger("IsWatch");
       else if (Input.GetKeyDown(KeyCode.R)) anime.SetTrigger("IsReload");
        #endregion

        #region Gun Switch
        #endregion
    }
    private void Jump(float Height) => Force.y += mass + Mathf.Sqrt(2f * -Physics.gravity.y * gavityScale * Height);
}
