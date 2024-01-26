using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkState : BossBaseState
{
    public override void EnterState(BossStateManager boss)
    {

    }

    public override void UpdateState(BossStateManager boss)
    {
        if (boss.CheckMinionStatus() == false) {
            boss.animator.SetBool("isWalking", true);
            boss.agent.SetDestination(boss.wallPoint.transform.position);
        }

        if (Vector3.Distance(boss.transform.position, boss.wallPoint.transform.position) < 1f) {
            boss.agent.SetDestination(boss.transform.position);
            boss.animator.SetBool("isWalking", false);
            boss.SwitchState(boss.SwipeState);
        }
    }

}
