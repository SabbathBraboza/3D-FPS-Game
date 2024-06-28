using TPS.Player;

public abstract class MovementBaseState
{
    public abstract void EnterState(MovementState movement);
    public abstract void UpdateState(MovementState movement);

}
