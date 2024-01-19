using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttackState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion) {
        Debug.Log("Entering Attack State");
    }

    public override void UpdateState(MinionStateManager minion) {
        Debug.Log("Updating Attack State");
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision) {
        Debug.Log("Colliding in Attack State");
    }
}