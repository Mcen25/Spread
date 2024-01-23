using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionStateManager : MonoBehaviour
{
    MinionBaseState currentState;
    public MinionIdleState IdleState = new MinionIdleState();
    public MinionChaseState ChaseState = new MinionChaseState();
    public MinionAttackState AttackState = new MinionAttackState();
    public MinionConsumeState ConsumeState = new MinionConsumeState();
    
    // public Collision collision;
    public GameObject[] targets;
    public NavMeshAgent agent;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject player;

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

    public void IsEnemyClose(MinionStateManager minion, GameObject player) {
        if (Vector3.Distance(minion.transform.position, minion.player.transform.position) < 4.0f) {
            SwitchState(AttackState);
        }
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
}
