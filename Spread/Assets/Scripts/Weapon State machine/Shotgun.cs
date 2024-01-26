using System;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private int ammo = 5;
    int reloadCount = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public float damage = 10f;
    public float range = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0) {
            animator.SetBool("CockBack", false);
            animator.SetBool("ShootCockTwice", true);
            Debug.Log(ammo);
        } else if (Input.GetButtonDown("Fire1") && ammo == 0) {
            EmptyAudio();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Debug.Log("Regular Reload");
            animator.SetBool("ShootCockTwice", false);
            animator.SetBool("ReloadWhileNotBack", true);

        }
    }


    public void EndRegularReload() {

        if (ammo < 5) {
            animator.SetBool("CockBack", false);
            animator.SetBool("Reload", true);
            ammo++;
        } 
        
        if (ammo >= 4) {
            animator.SetBool("Reload", false); 
            animator.SetBool("CockBack", true);
        }
        Debug.Log(ammo);
        
        animator.SetBool("ReloadWhileNotBack", false);
    }

    public void EndShootAnimation() {
        animator.SetBool("ShootCockTwice", false);
        ammo--;
    }

    public void EndLastShotAnimation() {
        animator.SetBool("ShootCockOnly", false);
        animator.SetBool("StayBack", true);
        ammo--;
    }

    public void EndCockBack() {
        animator.SetBool("CockBack", false);
    }

    public void PlayShotAudio() {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayReloadAudio() {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void CockBackAudio() {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    public void CockBackAndForthAudio() {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }

    private void EmptyAudio() {
        audioSource.clip = audioClips[4];
        audioSource.Play();
    }

    private void Shoot() {

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);

            MinionStateManager minion = hit.transform.GetComponent<MinionStateManager>();
            if (minion != null) {
                minion.DecreaseHealth(damage);
            }

            BossStateManager boss = hit.transform.GetComponent<BossStateManager>();
            if (boss != null) {
                boss.DecreaseHealth(damage);
            }
        }
    }

}