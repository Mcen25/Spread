using UnityEngine;

public class Shotgun : MonoBehaviour
{
    // Start is called before the first frame update
    private int ammo = 5;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Camera fpsCam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && ammo > 1) {
            Debug.Log("Shoot");
            animator.SetBool("Shoot", true);
            Debug.Log(ammo);
        } 
        
        if (Input.GetButtonDown("Fire1") && ammo == 1) {
            Debug.Log("Last Shot");
            animator.SetBool("LastShot", true);
            animator.SetBool("StayBack", true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo != 5) {
                animator.SetBool("StayBack", false);
                if (ammo == 4) {
                    animator.SetBool("ReloadLastShot", true);
                    ammo++;
                } else if (ammo < 4) {
                    while (ammo < 4) {
                        animator.SetBool("Reload", true);
                        
                    }
                }
            }
        }    
    }

    public void EndAnimation()
    {
        animator.SetBool("Reload", false);
        animator.SetBool("ReloadLastShot", false);
        ammo++;
    }

    public void EndShootAnimation() {
        animator.SetBool("Shoot", false);
        ammo--;
    }

    public void EndLastShotAnimation() {
        animator.SetBool("LastShot", false);
        animator.SetBool("StayBack", true);
        ammo--;
    }

}