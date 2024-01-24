using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    void Start()
    {
        Cursor.visible = true;
    }
    public void SetVolume (float volume) {
        audioMixer.SetFloat("volume", volume);    
    }

    public void SetFullscreen (bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
