using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaseState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.targets == null)
        {
            minion.SwitchState(minion.IdleState);
        }
        else
        {
            minion.agent.SetDestination(minion.targets[0].transform.position);
        }
    }

    public override void OnCollisionEnter(Collision collision, MinionStateManager minion)
    {
        throw new System.NotImplementedException();
    }
}
