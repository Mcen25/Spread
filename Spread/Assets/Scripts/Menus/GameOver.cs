using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
     [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    void Start()
    {
        Cursor.visible = true;
    }

    void Update() {
        if (gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ReturnToMainMenu()
    {
        // Load the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
}
