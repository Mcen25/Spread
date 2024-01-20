using UnityEngine;

public class ShotgunReloadState : ShotgunBaseState
{
    public override void EnterState(ShotgunStateManager shotgun) {
        Debug.Log("Entering Idle State");
    }
    public override void UpdateState(ShotgunStateManager shotgun) {

    }
    
}
