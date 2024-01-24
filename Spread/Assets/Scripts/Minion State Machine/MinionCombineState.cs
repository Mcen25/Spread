using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCombineState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Combine State");
        // minion.animator.SetBool("Combine", true);
    }

    public override void UpdateState(MinionStateManager minion)
    {
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

    // private void combineMinions(MinionStateManager minion) {
    //     Destroy(minion);
    // }

}
