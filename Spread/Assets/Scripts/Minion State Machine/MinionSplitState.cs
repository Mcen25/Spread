using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSplitState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Split State");
        minion.animator.SetBool("isWalking", false);
        minion.animator.SetBool("Splitting", true);
        minion.SpawnMinion(minion, minion.clone);
    }

    public override void UpdateState(MinionStateManager minion)
    {

    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

}
