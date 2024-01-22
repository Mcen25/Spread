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
        minion.animator.SetBool("isEating", true);

        minion.StartCoroutine(DeactivateFoodAfterDelay(minion));
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.targets[0].activeSelf == false) {
            minion.SwitchState(minion.IdleState);
        }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        
    }

    private IEnumerator DeactivateFoodAfterDelay(MinionStateManager minion)
    {
        Debug.Log("Waiting to deactivate food");
        yield return new WaitForSeconds(15f);
        minion.targets[0].SetActive(false);
    }
}
