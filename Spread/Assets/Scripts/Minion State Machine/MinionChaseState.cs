using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaseState : MinionBaseState
{
    public override void EnterState(MinionStateManager minion)
    {
        if (minion.animator == null)
        {
            Debug.Log("Animator is null");
        }
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.targets == null)
        {
            minion.animator.SetBool("isWalking", false);
            minion.SwitchState(minion.IdleState);
        }
        else
        {
            minion.animator.SetBool("isWalking", true);
            minion.agent.SetDestination(minion.targets[0].transform.position);
            // if (minion.targets[0].transform.position) {

            // }
        }
    }

    public override void OnCollisionEnter(Collision collision, MinionStateManager minion)
    {
        // if (collision.gameObject.tag == "Food")
        // {
        //     Debug.Log("Target is within site");
        // }
    }
}
