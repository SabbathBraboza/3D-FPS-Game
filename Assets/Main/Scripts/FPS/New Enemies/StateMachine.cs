using UnityEngine;

public class StateMachine : MonoBehaviour
{
      public BaseState ActiveState;

      private void Update()
      {
            ActiveState?.Perform();
      }

      public void Initialise()
      {
       
        ChangeState(new PatrollerState());
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

                  ActiveState.enemy = GetComponent<Robot_Enemy>();
                  ActiveState.Enter();
            }
      }
}
