using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class BossStateManager : MonoBehaviour
{
    public BossBaseState currentState;

    public BossIdleState IdleState = new BossIdleState();
    public BossAttackState AttackState = new BossAttackState();
    public BossSwipeState SwipeState = new BossSwipeState();
    public BossWalkState WalkState = new BossWalkState();
    public BossCapturedState CapturedState = new BossCapturedState();
    
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject player;
    public GameObject wallPoint;
    public Animator animator;

    public GameObject gameOver;
    public GameObject youWon;
    private float health = 200.0f;


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

    public void SwitchState(BossBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public bool IsEnemyClose(BossStateManager boss, GameObject player) {
        if (Vector3.Distance(boss.transform.position, boss.player.transform.position) < 15.0f) {
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

    public void DecreaseHealth(float damage) {
       
        if (currentState == SwipeState) {
             health -= damage;
            if (health <= 0) {
                Destroy(gameObject);
                youWon.SetActive(true);
            }
        }
        
    }

    public bool CheckMinionStatus() {
        GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
        foreach (GameObject minion in minions)
        {
            if (minion.activeSelf) {
                return true;
            }
        }
        return false;
    }
}
