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

        if (Vector3.Distance(boss.player.transform.position, boss.transform.position) <= 10.0f) {
            boss.agent.SetDestination(boss.player.transform.position);
        } else if (Vector3.Distance(boss.player.transform.position, boss.transform.position) <= 2.0f) {
            boss.agent.SetDestination(boss.transform.position);
            boss.player.GetComponent<Player>().DeathByBoss(100, boss);
            Debug.Log("Player killed");
        }
    }
}
