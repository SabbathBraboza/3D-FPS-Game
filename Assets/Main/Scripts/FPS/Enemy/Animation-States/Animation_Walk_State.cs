using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TPS.Enemy.Animation_State
{
    public class Animation_Walk_State : StateMachineBehaviour
    {
        float timer;
        private List<Transform> Waypoints = new List<Transform>();
        NavMeshAgent agent;
        Transform player;
        float ChaseDistance =4;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            agent = animator.GetComponent<NavMeshAgent>();
            agent.speed = 1f;
            timer = 0;
            GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
            Waypoints.Clear();
            foreach (Transform t in go.transform) Waypoints.Add(t);

            agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(Waypoints[Random.Range(0, Waypoints.Count)].position);

        timer += Time.deltaTime;
            if(timer > 3) animator.SetBool("Walking", false);

            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < ChaseDistance)
                animator.SetBool("Running", true);

        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(agent.transform.position);
        }
    }
}

