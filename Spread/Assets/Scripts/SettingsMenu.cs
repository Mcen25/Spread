using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
        Cursor.visible = true;
    }
    public void SetVolume (float volume) {
        audioMixer.SetFloat("volume", volume);    
    }

    public void SetFullscreen (bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
