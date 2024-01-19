using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaseState : MinionBaseState
{
    private float distance = 3.0f;
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Chase State");
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
        }

        if (Vector3.Distance(minion.targets[0].transform.position, minion.transform.position) < distance) {
            minion.SwitchState(minion.ConsumeState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        Debug.Log("Colliding in Chase State");
        GameObject other = collision.gameObject;
        if (other.CompareTag("Food"))
        {
            minion.animator.SetBool("isWalking", false);
            minion.SwitchState(minion.ConsumeState);
        }
    }
}
