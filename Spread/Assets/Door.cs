using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door; 
    public Animator animator;
    public AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp)) {
            animator.SetBool("SlideDown", false);
            animator.SetBool("SlideUp", true);
        }

        if (Input.GetKeyDown(KeyCode.PageDown)) {
            animator.SetBool("SlideUp", false);
            animator.SetBool("SlideDown", true);
        }
    }
}
