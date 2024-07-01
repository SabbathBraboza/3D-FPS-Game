using UnityEngine;

namespace TPS.Enemy.Animation_State
{
    public class Animation_Idle_State : StateMachineBehaviour
    {
        float timer;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 0;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer += Time.deltaTime;
            if (timer > 5)
                 animator.SetBool("Walking", true);
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}