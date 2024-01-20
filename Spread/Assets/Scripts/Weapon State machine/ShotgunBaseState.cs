using UnityEngine;

public abstract class ShotgunBaseState
{
    public abstract void EnterState(ShotgunStateManager shotgun);
    public abstract void UpdateState(ShotgunStateManager shotgun);
    
}
