using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MinionCombineState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Combine State");
        minion.agent.SetDestination(minion.sourcePoint.transform.position);
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (Vector3.Distance(minion.sourcePoint.transform.position, minion.transform.position) <= 2.0f) {
            minion.DecreaseHealth(20);
            IncreaseSize(minion);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

    void IncreaseSize(MinionStateManager minion) {
        minion.boss.transform.localScale += new Vector3(1.1f, 1.1f, 1.1f);
    }

}
