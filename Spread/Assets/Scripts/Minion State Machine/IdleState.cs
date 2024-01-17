using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IdleState : BaseState<MinionStateMachine.EMinionState>
{
    public IdleState(MinionStateMachine.EMinionState key) : base(key)
    {

    }

    public override void EnterState()
    {
        // Logic for entering the idle state
    }

    public override void ExitState()
    {
        // Logic for exiting the idle state
    }

    public override void UpdateState()
    {
        // Logic for updating the idle state
    }

    public override MinionStateMachine.EMinionState GetNextState()
    {
        // Logic for determining the next state from the idle state
        return MinionStateMachine.EMinionState.Chase;
    }

    public override void OnTriggerEnter(Collider other)
    {
        // Logic for handling trigger enter events in the idle state
    }

    public override void OnTriggerStay(Collider other)
    {
        // Logic for handling trigger stay events in the idle state
    }

    public override void OnTriggerExit(Collider other)
    {
        // Logic for handling trigger exit events in the idle state
    }
}
