using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStateMachine : BaseStateManager<MinionStateMachine.EMinionState>
{
    public enum EMinionState {
        Idle,
        Chase,
        Attack,
        Dead, 
        Consume, 
        Split, 
        Combine,
    }

    // public Dictionary<EMinionState, MinionStateMachine> States { get; } = new Dictionary<EMinionState, MinionStateMachine>();

    void Awake() {
        CurrentState = States[EMinionState.Idle];
        
    }
}
