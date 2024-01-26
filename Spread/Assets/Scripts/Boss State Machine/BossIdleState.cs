using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossBaseState
{
    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Idle State");
        // boss.animator.SetBool("isIdle", true);
    }

    public override void UpdateState(BossStateManager boss)
    {
        if (boss.IsEnemyClose(boss, boss.player)) {
            boss.SwitchState(boss.AttackState);
        } else if (boss.CheckMinionStatus() == false) {
            boss.SwitchState(boss.WalkState);
        }
    }

}
