using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public override void EnterState(BossStateManager boss)
    {
        boss.animator.SetBool("Swipping", false);
    }

    public override void UpdateState(BossStateManager boss)
    {

          if (boss.IsEnemyClose(boss, boss.player)) {
            if (Vector3.Distance(boss.player.transform.position, boss.transform.position) <= 5.0f) {
                boss.agent.SetDestination(boss.transform.position);
                boss.player.GetComponent<Player>().DeathByBoss(2, boss);
                boss.animator.SetBool("isWalking", false);
                boss.animator.SetBool("Attacking", true);
                Debug.Log("Player killed");
            } else {
                boss.animator.SetBool("Attacking", false);
                boss.agent.SetDestination(boss.player.transform.position);
            }
        } else {
            boss.SwitchState(boss.IdleState);
        }
    }
}
