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
        minion.animator.SetBool("IsWalking", false);
        minion.animator.SetBool("IsEating", true);

        if (minion.IsEnemyClose(minion, minion.player)) {
            minion.SwitchState(minion.AttackState);
        } else {
            minion.StartCoroutine(DeactivateFoodAfterDelay(minion));   
        }
    }

    public override void UpdateState(MinionStateManager minion)
    {
        
        if (minion.IsEnemyClose(minion, minion.player)) {
            minion.SwitchState(minion.AttackState);
        }
        
        // if (FindClosestTarget(minion).activeSelf == false) {
        //     minion.SwitchState(minion.IdleState);
        // }
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        
    }

    private IEnumerator DeactivateFoodAfterDelay(MinionStateManager minion)
    {
        Debug.Log("Waiting to deactivate food");
        GameObject closestFood = FindClosestTarget(minion);
        yield return new WaitForSeconds(5f);
        
        closestFood.SetActive(false);
        minion.animator.SetBool("IsEating", false);
        minion.SwitchState(minion.SplitState);

    }

    private GameObject FindClosestTarget(MinionStateManager minion) {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Food");
        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            if (target.activeSelf == true) {
                float distanceToTarget = Vector3.Distance(target.transform.position, minion.transform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestTarget = target;
                }
            } 
        }
        return closestTarget;
    }
}
