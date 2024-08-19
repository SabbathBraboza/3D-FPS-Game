using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
      [Header("V A L U E")]
      [SerializeField] private bool follow;
      [SerializeField] private bool RandomPointReached;
      [SerializeField] private float FollowDistance = 10.0f;
      [SerializeField] private float AttackDistance = 2.0f;
      [SerializeField] private Vector3 randomPosition;
      public float RandomMoveRadius = 60f;
      private bool isAtRandomPoint => !Agent.pathPending && Agent.remainingDistance <= Agent.stoppingDistance;

      [Header("REFERENCE")]
      [SerializeField] private NavMeshAgent Agent;
      [SerializeField] private GameObject Target;
      [SerializeField] private Animator _anim;
      [SerializeField] private Transform LookAt;
      [SerializeField] private GameObject spawnEnemy;
      [SerializeField] private ZombieAttack zombieAttack;

      private int PaceH = Animator.StringToHash("Pace");
      private int AttackH = Animator.StringToHash("Attack");

      private void Reset()
      {
            _anim = GetComponent<Animator>();
            Agent = GetComponent<NavMeshAgent>();
      }
      private void Start()
      {
            Target = GameObject.FindGameObjectWithTag("Player");
            spawnEnemy = GameObject.FindWithTag("Spawn");
            AttackDistance = 3;
            RandomPointReached = true;
      }
      private void Update()
      {
            float dist = Vector3.Distance(Target.transform.position, this.transform.position);
            follow = (dist < FollowDistance);
            if (follow)
            {
                  Agent.SetDestination(Target.transform.position);
                  Move(Agent.velocity.magnitude);
                  RandomPointReached = false;
                  if ((dist <= AttackDistance))
                     Attack(true);
               
                  else
                     Attack(false);
            }
            else
            {
                  if (RandomPointReached)
                  {
                        randomPosition = GenerateRandomPosition();
                        Agent.SetDestination(randomPosition);
                        RandomPointReached = false;
                  }
                  if (isAtRandomPoint)
                  {
                        RandomPointReached = true;
                  }
                  Attack(false);
            }
            if (isAtRandomPoint && !follow)
            {
                  LookAt.transform.LookAt(Target.transform);
                  transform.rotation = Quaternion.Euler(0f, LookAt.transform.eulerAngles.y, 0f);
                  Move(Agent.velocity.magnitude);
            }
      }
      private Vector3 GenerateRandomPosition()
      {
            Vector3 randomDirection = Random.insideUnitSphere * RandomMoveRadius;
            randomDirection += transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randomDirection, out navHit, RandomMoveRadius, -1);
            RandomPointReached = true;
            return navHit.position;
      }
      private void Move(float value)
      {
            _anim.SetFloat(PaceH, value);
      }
      private void Attack(bool value)
      {
            _anim.SetBool(AttackH, value);
      }
}
