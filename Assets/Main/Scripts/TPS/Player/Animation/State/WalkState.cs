using TPS.Player;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementState movement)
    {
        movement.anime.SetBool("IsWalking", true);
    }

    public override void UpdateState(MovementState movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Run);
        else if(movement.dir.magnitude <0.1f) ExitState(movement, movement.idle);

        if(movement.VInput<0) movement.CurrentMoveSpeed = movement.WalkBackSpeed;
        else movement.CurrentMoveSpeed = movement.WalkSpeed;
    }

    public void ExitState(MovementState movement , MovementBaseState State)
    {
        movement.SwitchState(State);
        movement.anime.SetBool("IsWalking", false);
    }
}
