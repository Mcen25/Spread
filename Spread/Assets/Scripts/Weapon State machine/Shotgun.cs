using UnityEngine;

public class Shotgun : MonoBehaviour
{
    // Start is called before the first frame update
    private int ammo = 5;

    int reloadCount = 0;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Camera fpsCam;

    public float damage = 10f;
    public float range = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && ammo > 0) {
            Debug.Log("Shoot");
            animator.SetBool("Shoot", true);
            Debug.Log(ammo);
        } 
        
        if (Input.GetButtonDown("Fire1") && ammo == 0) {
            Debug.Log("Last Shot");
            Debug.Log(ammo);
            animator.SetBool("Shoot", true);
            animator.SetBool("StayBack", true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammo <= 5) {
                if (animator.GetBool("StayBack") == true) {
                    animator.SetBool("StayBack", false);
                    animator.SetBool("Reload", true);
                }

                if (animator.GetBool("StayBack") == false) {
                    animator.SetBool("Reload", true);
                }
            }
        }    
    }

    public void EndAnimation()
    {
        reloadCount++;
        if (reloadCount == 5) {
            animator.SetBool("Reload", false);
            animator.SetBool("ReloadLastShot", false);
            reloadCount = 0;
        }
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

    public void PlayShotAudio() {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    private void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);
        }
    }

}