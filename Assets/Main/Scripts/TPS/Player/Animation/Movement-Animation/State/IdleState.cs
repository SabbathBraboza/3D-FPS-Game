using TPS.Player;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementState movement)
    {

    }

    public override void UpdateState(MovementState movement)
    {
         if(movement.dir.magnitude > 0.1f) 
        {
          if(Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            
          else movement.SwitchState(movement.Walk);
        }
    }
}
