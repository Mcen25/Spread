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

    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        
    }

    private IEnumerator DeactivateFoodAfterDelay(MinionStateManager minion)
    {
        Debug.Log("Waiting to deactivate food");
        yield return new WaitForSeconds(15f);
        GameObject closestFood = FindClosestTarget(minion);
        closestFood.SetActive(false);
        minion.SwitchState(minion.IdleState);
    }

    private GameObject FindClosestTarget(MinionStateManager minion) {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Food");
        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector3.Distance(target.transform.position, minion.transform.position);
            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                closestTarget = target;
            }
        }

        return closestTarget;
    }
}
