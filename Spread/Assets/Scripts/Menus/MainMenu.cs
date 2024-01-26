using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    public GameObject mainMenu;

    void Update()
    {
        if (mainMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayGameSound();
        }
    }
    public void PlayGame()
    {
        // Load the next scene in the build index
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Main Playroom");
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void PlayHoverSound()
    {
        Debug.Log("Hovering and played sound");
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayerClickSound()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void PlayGameSound()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }
}
