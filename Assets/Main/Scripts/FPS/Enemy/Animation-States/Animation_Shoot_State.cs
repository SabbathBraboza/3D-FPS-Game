using UnityEngine;

public class Animation_Shoot_State : StateMachineBehaviour
{
    Transform player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3f)
            animator.SetBool("Attacking", false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
