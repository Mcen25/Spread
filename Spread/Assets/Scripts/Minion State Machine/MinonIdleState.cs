using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionIdleState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Idle State");
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.IsEnemyClose(minion, minion.player)) {
            minion.SwitchState(minion.AttackState);
        } else if (minion.CheckFoodActivity() != false) {
            minion.SwitchState(minion.ChaseState);
        } else {
            minion.animator.SetBool("isWalking", false);
        }

    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

}
