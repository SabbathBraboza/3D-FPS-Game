using UnityEngine;
using UnityEngine.AI;

public class Robot_Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private StateMachine State;

    public NavMeshAgent Agent { get => agent; }

    [SerializeField] private GameObject Player;

    [SerializeField] private float SightDistance = 10f;
    [SerializeField] private float FOV = 85f;
    [SerializeField] private float EyeHight;

      [SerializeField]
      private string currentState;

      public Path Path;
      private void Start()
      {
            State = GetComponent<StateMachine>();
            agent = GetComponent<NavMeshAgent>();
            State.Initialise();
      }


    private void Update()
    {
        CanSeePlayer();
        currentState = State.ActiveState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (Player != null)
        {
            // Is Player close enough to be seen
            if (Vector3.Distance(transform.position, Player.transform.position) < SightDistance)
            {
                Vector3 TargetDirction = Player.transform.position - transform.position - (Vector3.up * EyeHight);
                float AngleToPlayer = Vector3.Angle(TargetDirction, transform.forward);
                if (AngleToPlayer >= -FOV && AngleToPlayer <= FOV)
                {
                    Ray ray = new Ray(transform.position +(Vector3.up * EyeHight), TargetDirction);
                    RaycastHit hitinfo = new();
                    if(Physics.Raycast(ray, out hitinfo))
                    {
                        if(hitinfo.transform.gameObject == Player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawLine(ray.origin, ray.direction * SightDistance);
                }
            }
        }
        return false;
    }
}
