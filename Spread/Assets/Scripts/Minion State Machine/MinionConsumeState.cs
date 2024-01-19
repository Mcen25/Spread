using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionConsumeState : MinionBaseState
{

    [SerializeField] private float distance = 100.0f;
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Consume State");
        minion.agent.SetDestination(minion.transform.position);
        minion.animator.SetBool("isWalking", false);
        minion.animator.SetBool("IsEating", true);
    }

    public override void UpdateState(MinionStateManager minion)
    {

    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        
    }
}
