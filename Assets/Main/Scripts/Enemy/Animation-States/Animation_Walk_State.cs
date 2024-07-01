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

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent = animator.GetComponent<NavMeshAgent>();
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
            if(timer > 10) animator.SetBool("Walking", false);

        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            agent.SetDestination(agent.transform.position);
        }
    }
}

