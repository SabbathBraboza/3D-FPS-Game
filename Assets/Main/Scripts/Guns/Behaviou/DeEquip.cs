using UnityEngine;

public class DeEquip : StateMachineBehaviour
{
      public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
      {
            animator.gameObject.SetActive(false);
      }
}
