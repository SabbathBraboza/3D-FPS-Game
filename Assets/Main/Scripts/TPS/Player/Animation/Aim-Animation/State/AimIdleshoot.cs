using TPS.Player;
using UnityEngine;

public class AimIdleshoot : AimStateBase
{
    public override void EnterState(AimState aim)
    {
        aim.anime.SetBool("Aiming", false);
        aim.CurrentFov = aim.HipFov;
    }
    public override void UpdateState(AimState aim)
    {
        if (Input.GetKey(KeyCode.Mouse0)) aim.SwitchState(aim.shoot); 
    }

}
