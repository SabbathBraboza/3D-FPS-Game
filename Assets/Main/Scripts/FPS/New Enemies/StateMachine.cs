using UnityEngine;

public class StateMachine : MonoBehaviour
{
      private BaseState ActiveState;



      private void Update()
      {
            ActiveState?.Perform();
      }

      public void Initialise()
      {
            
      }

      public void ChangeState(BaseState state)
      {
            // check ActiveState is not null

            // run cleanup on ActiveState
            ActiveState?.Exit();

            // Change to a new State
            ActiveState = state;

            // Fail safe null check to make sure new state wasn't null
            if(ActiveState != null )
            {
                  ActiveState.StateMachine = this;

                  // Assign State enemy class
                  ActiveState.Enter();
            }
      }
}
