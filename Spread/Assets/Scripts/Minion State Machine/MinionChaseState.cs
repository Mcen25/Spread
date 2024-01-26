using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaseState : MinionBaseState
{
    private float distance = 5.0f;
    public override void EnterState(MinionStateManager minion)
    {
        Debug.Log("Entering Chase State");

        minion.audioSource.clip = minion.audioClips[0];
        minion.audioSource.Play();
        minion.animator.SetBool("IsWalking", true);
       
    }

    public override void UpdateState(MinionStateManager minion)
    {
        if (minion.IsEnemyClose(minion, minion.player)) {
            minion.SwitchState(minion.AttackState);
        } else 
        if (minion.CheckFoodActivity() == false) {
            minion.SwitchState(minion.CombineState);
        } else {
            minion.agent.SetDestination(FindClosestTarget(minion).transform.position);
             if (FindClosestTarget(minion).activeSelf == true && Vector3.Distance(FindClosestTarget(minion).transform.position, minion.transform.position) < distance)
            {
                minion.audioSource.Stop();
                minion.SwitchState(minion.ConsumeState);
            } 
        }
      
    }

    public override void OnCollisionEnter(MinionStateManager minion, Collision collision)
    {
        Debug.Log("Colliding in Chase State");
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
                    if (NumberOfMinionsNearFood(target, minion) <= 3) {
                        closestDistance = distanceToTarget;
                        closestTarget = target;
                    } else {
                        continue;
                    }
                }
            } 
        }

        return closestTarget;
    }

    private int NumberOfMinionsNearFood(GameObject food, MinionStateManager minion) {
        int count = 0;
        int distanceFromFood = 6;

        Collider[] colliders = Physics.OverlapSphere(food.transform.position, distanceFromFood);
        foreach (Collider collider in colliders)
        {
            MinionStateManager otherMinion = collider.GetComponent<MinionStateManager>();
            if (otherMinion != minion)
            {
                count++;
            }
        }

        return count;
    }
}
