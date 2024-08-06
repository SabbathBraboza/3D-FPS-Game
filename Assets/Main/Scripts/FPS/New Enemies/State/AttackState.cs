using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    [SerializeField] private float MoveTimer;
    [SerializeField] private float LosePlayerTimer;





    public override void Enter()
    {
      
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            LosePlayerTimer = 0;
            MoveTimer += Time.deltaTime;
            if (MoveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                MoveTimer = 0;
            }
        }
        else
        {
            LosePlayerTimer += Time.deltaTime;
            if(LosePlayerTimer > 5)
            {
                ////
                StateMachine.ChangeState(new PatrollerState());
            }
        }
    }
}
