using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossBaseState
{
    public override void EnterState(BossStateManager boss)
    {

    }

    public override void UpdateState(BossStateManager boss)
    {

          if (boss.IsEnemyClose(boss, boss.player)) {
            if (Vector3.Distance(boss.player.transform.position, boss.transform.position) <= 5.0f) {
                boss.agent.SetDestination(boss.transform.position);
                boss.player.GetComponent<Player>().DeathByBoss(2, boss);
                Debug.Log("Player killed");
            } else {
                boss.agent.SetDestination(boss.player.transform.position);
            }
        } else {
            boss.SwitchState(boss.IdleState);
        }
    }
}
