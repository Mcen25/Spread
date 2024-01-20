using UnityEngine;

public class ShotgunShootState : ShotgunBaseState
{
    private int damage;
    private int range;
    private int pellets; 
    private float fireRate;
    private float reloadTime;
    private float spread;
    private float nextFire;
    private float reload;
    private float nextReload;

    public override void EnterState(ShotgunStateManager shotgun) {
        Debug.Log("Entering Idle State");
        Shoot(shotgun);
        shotgun.SwitchState(shotgun.shotgunIdleState);
    }
    public override void UpdateState(ShotgunStateManager shotgun) {
        
    }

    void Shoot(ShotgunStateManager shotgun) {
        RaycastHit hit;

        if (Physics.Raycast(shotgun.fpsCam.transform.position, shotgun.fpsCam.transform.forward, out hit, range)) {
            Debug.Log("hit");
        }
    }
    
}
