using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionIdleState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.targets != null) {
            minion.SwitchState(minion.ChaseState);
        }
    }

    public override void OnCollisionEnter(Collision collision, MinionStateManager minion)
    {
        throw new System.NotImplementedException();
    }
}
