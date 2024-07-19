using UnityEngine;


namespace FPS.Weapon.State
{
      using Utility;
      public class Reload : StateMachineBehaviour
      {
            public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
            {
                  animator.speed = 1f;

                  animator.SetBool(Hash.Reload, false);

                  animator.GetComponent<Gun>().Refill();
            }
      }  
}
