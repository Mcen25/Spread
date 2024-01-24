using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionStateManager : MonoBehaviour
{
    public MinionBaseState currentState;
    public MinionIdleState IdleState = new MinionIdleState();
    public MinionChaseState ChaseState = new MinionChaseState();
    public MinionAttackState AttackState = new MinionAttackState();
    public MinionConsumeState ConsumeState = new MinionConsumeState();
    public MinionSplitState SplitState = new MinionSplitState();
    
    // public Collision collision;
    public GameObject[] targets;
    public NavMeshAgent agent;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject player;
    public GameObject clone;

    public Animator animator;
    void Awake() {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start() {
        currentState = IdleState;

        currentState.EnterState(this);
    }

    void Update() {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter(Collision collision) {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(MinionBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public bool IsEnemyClose(MinionStateManager minion, GameObject player) {
        if (Vector3.Distance(minion.transform.position, minion.player.transform.position) < 4.0f) {
            return true;
        }

        return false;
    }

    public bool CheckFoodActivity() {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject food in foods)
        {
            if (food.activeSelf) {
                return true;
            }
        }
        return false;
    }

    public void SpawnMinion(MinionStateManager minion, GameObject clone) {
        Vector3 spawnPosition = minion.transform.position + minion.transform.forward * 1.2f; 
        Instantiate(clone, spawnPosition, Quaternion.identity);
        minion.SwitchState(minion.IdleState);
    }

    public void EndBirthAnimation() {
        animator.SetBool("Splitting", false);
    }
}
