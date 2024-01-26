using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwipeState : BossBaseState
{

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Swipe State");
        
    }

    public override void UpdateState(BossStateManager boss)
    {
        if (Vector3.Distance(boss.transform.position, boss.wallPoint.transform.position) < 1f) {
            boss.agent.SetDestination(boss.transform.position);
            boss.animator.SetBool("Swiping", true);
            boss.StartCoroutine(EndGameTimer(boss));      
        }

    }

    private IEnumerator EndGameTimer(BossStateManager boss)
    {
        yield return new WaitForSeconds(30f);
        boss.gameOver.SetActive(true);

    }

}
