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
        if (minion.targets != null) {
            // minion.animator.SetBool("isWalking", true);
            minion.SwitchState(minion.ChaseState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }
}
