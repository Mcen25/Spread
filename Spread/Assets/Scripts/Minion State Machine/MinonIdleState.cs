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
        if (CheckFoodActivity() != false) {
            minion.SwitchState(minion.ChaseState);
        } else {
            minion.animator.SetBool("isWalking", false);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {

    }

    private bool CheckFoodActivity() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject target in targets)
        {
            if (target.activeSelf) {
                return true;
            }
        }
        return false;
    }
}
