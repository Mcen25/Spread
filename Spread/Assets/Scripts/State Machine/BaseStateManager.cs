using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseStateManager<EState> : MonoBehaviour where EState : Enum
{
    Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;

    protected bool IsTransitiongState = false;

    void Start() {
        CurrentState.EnterState();
    }

    void Update() {
        EState nextStateKey = CurrentState.GetNextState();

        if (nextStateKey.Equals(CurrentState.StateKey)) {
            CurrentState.UpdateState();
        } else if (!IsTransitiongState) {
           TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState stateKey) {
        IsTransitiongState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        IsTransitiongState = false;
    }

    void OnTriggerEnter(Collider other) {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other) {
        CurrentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other) {
        CurrentState.OnTriggerExit(other);
    }
}
