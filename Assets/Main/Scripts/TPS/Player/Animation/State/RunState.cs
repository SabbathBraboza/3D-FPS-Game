using TPS.Player;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementState movement)
    {
        movement.anime.SetBool("IsRunning", true);
    }

    public override void UpdateState(MovementState movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if(movement.dir.magnitude < 0.1f) ExitState(movement, movement.idle);

        if (movement.VInput < 0) movement.CurrentMoveSpeed = movement.RunBackSpeed;
        else movement.CurrentMoveSpeed = movement.RunSpeed;
    }
    public void ExitState(MovementState movement, MovementBaseState State)
    {
        movement.SwitchState(State);
        movement.anime.SetBool("IsRunning", false);
    }

}
