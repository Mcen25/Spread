using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttackState : MinionBaseState
{
    private float agentSpeed = 5.0f;

    public override void EnterState(MinionStateManager minion) {
        Debug.Log("Entering Attack State");
        minion.animator.SetBool("isWalking", false);
        minion.animator.SetBool("isAttacking", true);
        minion.animator.SetBool("isEating", false);

        minion.agent.speed = agentSpeed;

        minion.agent.SetDestination(minion.player.transform.position);
    }

    public override void UpdateState(MinionStateManager minion) {
        Debug.Log("Updating Attack State");
        // if () {

        // }


    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision) {
        Debug.Log("Colliding in Attack State");
    }

    private void AttackPlayer(MinionStateManager minion) {
        // minion.player.GetComponent<PlayerHealth>()

        if (Vector3.Distance(minion.player.transform.position, minion.transform.position) > 2.0f) {
            minion.agentSpeed
        }
    }
}