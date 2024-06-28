using TPS.Player;
using UnityEngine;

public class AimShoot : AimStateBase
{
    public override void EnterState(AimState aim)
    {
        aim.anime.SetBool("Aiming", true);
        aim.CurrentFov = aim.adsfov;
    }
    public override void UpdateState(AimState aim)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0)) aim.SwitchState(aim.idle);
    }

}
