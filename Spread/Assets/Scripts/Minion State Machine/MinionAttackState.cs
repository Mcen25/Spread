using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttackState : MinionBaseState
{
    private float agentSpeed = 5.0f;

    public override void EnterState(MinionStateManager minion) {
        Debug.Log("Entering Attack State");
        minion.animator.SetBool("IsWalking", false);     
        minion.animator.SetBool("CanAttack", true);
        minion.animator.SetBool("IsEating", false);

        minion.agent.speed = 15f;

    }

    public override void UpdateState(MinionStateManager minion) {
         
        if (minion.IsEnemyClose(minion, minion.player)) {
            if (Vector3.Distance(minion.player.transform.position, minion.transform.position) <= 5.0f) {
                minion.agent.SetDestination(minion.transform.position);
                minion.animator.SetBool("CanAttack", false);
                minion.animator.SetBool("Attacking", true);
                minion.player.GetComponent<Player>().DecreaseHealth(1, minion);
                Debug.Log("Player killed");
            } else {
                minion.agent.SetDestination(minion.player.transform.position);
                minion.animator.SetBool("CanAttack", true);
                minion.animator.SetBool("Attacking", false);
            }
        } else {
            minion.agent.speed = 5.0f;
            minion.animator.SetBool("CanAttack", false);
            minion.SwitchState(minion.IdleState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision) {
        Debug.Log("Colliding in Attack State");
    }

}