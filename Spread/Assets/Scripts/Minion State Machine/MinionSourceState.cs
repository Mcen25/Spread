using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSourceState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Source State");
        minion.animator.SetBool("IsWalking", true);
        minion.animator.SetBool("IsEating", false);
        minion.animator.SetBool("CanAttack", false);
        minion.animator.SetBool("Splitting", false);
        minion.agent.SetDestination(minion.sourcePoint.transform.position);
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (Vector3.Distance(minion.sourcePoint.transform.position, minion.transform.position) <= 2.0f) {
            minion.SwitchState(minion.IdleState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

}
