using UnityEngine;

public class ShotgunIdleState : ShotgunBaseState
{
    public override void EnterState(ShotgunStateManager shotgun) {
        Debug.Log("Entering Idle State");
        shotgun.shotgunAnimator.SetBool("isIdle", true);
    }
    public override void UpdateState(ShotgunStateManager shotgun) {
        if (Input.GetMouseButtonDown(0)) {
            shotgun.SwitchState(shotgun.shotgunShootState);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            shotgun.SwitchState(shotgun.shotgunReloadState);
        }
    }
    
}
