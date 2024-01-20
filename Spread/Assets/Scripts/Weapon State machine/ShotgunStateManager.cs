using UnityEngine;

public class ShotgunStateManager : MonoBehaviour
{
    ShotgunBaseState currentState;

    public ShotgunIdleState shotgunIdleState = new ShotgunIdleState();
    public ShotgunShootState shotgunShootState = new ShotgunShootState();
    public ShotgunReloadState shotgunReloadState = new ShotgunReloadState();
    
    public AudioSource shotgunAudioSource;
    public AudioClip[] shotgunAudioClips;

    public Animator shotgunAnimator;

    public Camera fpsCam;

    void Awake() {
        shotgunAnimator = GetComponent<Animator>();
        shotgunAudioSource = GetComponent<AudioSource>();
        fpsCam = Camera.main;
    }

    void Start() {
        currentState = shotgunIdleState;
       
        currentState.EnterState(this);
    }

    void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(ShotgunBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }
}
