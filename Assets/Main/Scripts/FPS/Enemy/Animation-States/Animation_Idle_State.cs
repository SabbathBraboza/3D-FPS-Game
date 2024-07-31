using FPS.Player;
using UnityEngine;

namespace TPS.Enemy.Animation_State
{
    public class Animation_Idle_State : StateMachineBehaviour
    {
        float timer;
       public Transform player;
        readonly float ChaseDistance = 4;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           player = GameObject.FindWithTag("Player").transform;
            timer = 0;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer += Time.deltaTime;
            if (timer > 3)
                 animator.SetBool("Walking", true);

            float distance = Vector3.Distance(player.position, animator.transform.position);

            if(distance < ChaseDistance)
                animator.SetBool("Running", true);
              
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}