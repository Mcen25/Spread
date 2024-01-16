using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStateManager : MonoBehaviour
{
    MinionBaseState currentState;
    public MinionAttackState attackState = new MinionAttackState();
    public MinionIdleState idleState = new MinionIdleState();
    public MinionChaseState chaseState = new MinionChaseState();

    void OnCollisionEnter(Collision collision) {
        currentState.OnCollisionEnter(collision);
    }
    void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(MinionBaseState state) {
        currentState = state;
        state.EnterState(this);
    } 

}
