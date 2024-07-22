using UnityEngine;
using UnityEngine.AI;

public class Animation_Run_State : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform Player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
        agent.speed = 4f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(Player.position);

        float distance = Vector3.Distance(Player.position, animator.transform.position);
        if (distance > 15)
            animator.SetBool("Running", false);

        if(distance < 3)
          animator.SetBool("Attacking", true);    
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
