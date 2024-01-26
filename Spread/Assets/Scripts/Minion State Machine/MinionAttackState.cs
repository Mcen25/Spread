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

        minion.agent.speed = agentSpeed;

    }

    public override void UpdateState(MinionStateManager minion) {
         
        if (WithinRange(minion)) {
            AttackPlayer(minion);
        } else {
            minion.SwitchState(minion.IdleState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision) {
        Debug.Log("Colliding in Attack State");
    }

     private bool WithinRange(MinionStateManager minion) {
        if (Vector3.Distance(minion.player.transform.position, minion.transform.position) <= 10.0f) {
            return true;
        } else {
            return false;
        }
    }

    private void AttackPlayer(MinionStateManager minion) {
        // minion.player.GetComponent<PlayerHealth>()
        if (Vector3.Distance(minion.player.transform.position, minion.transform.position) <= 2.0f) {
            minion.agent.SetDestination(minion.transform.position);
            minion.animator.SetBool("CanAttack", false);
            minion.animator.SetBool("Attacking", true);
            minion.player.GetComponent<Player>().DecreaseHealth(2, minion);
            Debug.Log("Player killed");
        } else {
            minion.agent.SetDestination(minion.player.transform.position);
            minion.animator.SetBool("CanAttack", true);
            minion.animator.SetBool("Attacking", false);
        }
       
    }
}