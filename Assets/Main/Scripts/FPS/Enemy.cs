using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
      [Header("Values:")]
      [SerializeField] private float startWaitTime = 4f;
      [SerializeField] private float timeToRotate = 3f;
      [SerializeField] private float speedWalk = 6f;
      [SerializeField] private float speedRun = 9f;

      [Header("Enemy View:")]
      [SerializeField] private float viewRadius = 15f;
      [SerializeField] private float viewAngle = 90f;
      [SerializeField] private float meshResolution = 1f;
      [SerializeField] private int edgeIterations = 4;
      [SerializeField] private float edgeDistance = 0.5f;

      [Header("References")]
      [SerializeField] private LayerMask playerMask;
      [SerializeField] private LayerMask obstacleMask;
      [SerializeField] private Transform[] waypoints;

      private NavMeshAgent agent;
      private int currentWayPointIndex;
      private Vector3 playerLastPosition;
      private Vector3 playerPosition;
      private float waitTime;
      private float rotateTime;
      private bool playerInRange;
      private bool playerNear;
      private bool isPatrolling;
      private bool caughtPlayer;

      private void Start()
      {
            playerPosition = Vector3.zero;
            isPatrolling = true;
            caughtPlayer = false;
            playerInRange = false;
            waitTime = startWaitTime;
            rotateTime = timeToRotate;

            currentWayPointIndex = 0;

            agent = GetComponent<NavMeshAgent>();
            agent.speed = speedWalk;
            agent.SetDestination(waypoints[currentWayPointIndex].position);
      }

      private void Update()
      {
            EnvironmentView();
            if (isPatrolling)
            {
                  Patrolling();
            }
            else
            {
                  Chasing();
            }
      }

      private void CaughtPlayer()
      {
            caughtPlayer = true;
      }

      private void LookAtPlayer(Vector3 player)
      {
            agent.SetDestination(player);
            if (Vector3.Distance(transform.position, player) <= 0.3f)
            {
                  if (waitTime <= 0)
                  {
                        playerNear = false;
                        Move(speedWalk);
                        agent.SetDestination(waypoints[currentWayPointIndex].position);
                        waitTime = startWaitTime;
                        rotateTime = timeToRotate;
                  }
                  else
                  {
                        Stop();
                        waitTime -= Time.deltaTime;
                  }
            }
      }

      private void Move(float speed)
      {
            agent.isStopped = false;
            agent.speed = speed;
      }

      private void Stop()
      {
            agent.isStopped = true;
            agent.speed = 0;
      }

      private void NextPoint()
      {
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[currentWayPointIndex].position);
      }

      private void EnvironmentView()
      {
            Collider[] playersInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
            foreach (Collider player in playersInRange)
            {
                  Transform playerTransform = player.transform;
                  Vector3 dirToPlayer = (playerTransform.position - transform.position);

                  if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
                  {
                        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

                        if (!Physics.Raycast(transform.position, dirToPlayer, distanceToPlayer, obstacleMask))
                        {
                              playerInRange = true;
                              isPatrolling = false;
                              playerPosition = playerTransform.position;
                        }
                        else
                        {
                              playerInRange = false;
                        }

                        if (distanceToPlayer > viewRadius)
                        {
                              playerInRange = false;
                        }
                  }
            }
      }

      private void Patrolling()
      {
            if (playerNear)
            {
                  if (rotateTime <= 0)
                  {
                        Move(speedWalk);
                        LookAtPlayer(playerLastPosition);
                  }
                  else
                  {
                        Stop();
                        rotateTime -= Time.deltaTime;
                  }
            }
            else
            {
                  playerNear = false;
                  playerLastPosition = Vector3.zero;
                  agent.SetDestination(waypoints[currentWayPointIndex].position);

                  if (agent.remainingDistance < agent.stoppingDistance)
                  {
                        if (waitTime <= 0)
                        {
                              NextPoint();
                              Move(speedWalk);
                              waitTime = startWaitTime;
                        }
                        else
                        {
                              Stop();
                              waitTime -= Time.deltaTime;
                        }
                  }
            }
      }

      private void Chasing()
      {
            playerNear = false;
            playerLastPosition = Vector3.zero;

            if (caughtPlayer)
            {
                  Move(speedRun);
                  agent.SetDestination(playerPosition);
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                  if (waitTime <= 0 && !caughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
                  {
                        isPatrolling = true;
                        playerNear = false;
                        Move(speedWalk);
                        rotateTime = timeToRotate;
                        waitTime = startWaitTime;
                        agent.SetDestination(waypoints[currentWayPointIndex].position);
                  }
                  else
                  {
                        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                        {
                              Stop();
                              waitTime -= Time.deltaTime;
                        }
                  }
            }
      }
}
