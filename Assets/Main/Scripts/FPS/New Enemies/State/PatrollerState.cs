
public class PatrollerState : BaseState
{
      public  int WaypointIndex;

      public override void Enter()
      {
            
      }

      public override void Exit()
      {
            
      }

      public override void Perform()
      {
            
      }

      public void  PatrolCycle()
      {
            if (enemy.Agent.remainingDistance < 0.2f)
            {
                  if (WaypointIndex < enemy.Path.Waypoints.Count - 1)
                        WaypointIndex++;
                  else
                        WaypointIndex = 0;

            }
      }
}
