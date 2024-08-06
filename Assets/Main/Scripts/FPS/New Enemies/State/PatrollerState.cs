
using UnityEngine;

public class PatrollerState : BaseState
{
      public  int WaypointIndex;
       public float WaitTimer = 3;
      public override void Enter()
      {
            
      }

      public override void Exit()
      {
            
      }

      public override void Perform()
      {
        PatrolCycle();
        if(enemy.CanSeePlayer())
        {
            StateMachine.ChangeState(new AttackState());
        }
      }

      public void  PatrolCycle()
      {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            WaitTimer += Time.deltaTime;
            if (WaitTimer > 3)
            {
                if (WaypointIndex < enemy.Path.Waypoints.Count - 1)
                    WaypointIndex++;
                else
                    WaypointIndex = 0;

                enemy.Agent.SetDestination(enemy.Path.Waypoints[WaypointIndex].position);
                WaitTimer = 0;
            }
        }
      }
}
