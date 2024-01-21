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
        if (ammo == 0) {
            animator.SetBool("StayBack", true);
        }
        if (Input.GetButtonDown("Fire1") && ammo > 0) {
            Debug.Log("Shoot");
            animator.SetBool("Shoot", true);
            Debug.Log(ammo);
        } 

        if (Input.GetKeyDown(KeyCode.R))
        {
          if (ammo == 4) {
            animator.SetBool("ReloadLastShot", true);
            ammo++;
          } else if (ammo < 4) {
            while (ammo < 4) {
                animator.SetBool("Reload", true);
                ammo++;
            }
          }
        }    
    }

    public void EndAnimation()
    {
        animator.SetBool("Reload", false);
        animator.SetBool("ReloadLastShot", false);
        animator.SetBool("LastShot", false);
    }

    public void EndShootAnimation() {
        animator.SetBool("Shoot", false);
        ammo--;
    }

}