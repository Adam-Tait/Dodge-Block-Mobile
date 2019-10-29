using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public AudioSource audioSource;

    private int refreshRate;
    private float pastVolume = 1f;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volumeSlider.value = 1f;
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        }
        refreshRate = Screen.currentResolution.refreshRate;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
}

    public void Fullscreen ()
    {
        if (Screen.fullScreen == true)
        {
            Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length - 3].width, Screen.resolutions[Screen.resolutions.Length - 3].height, false, refreshRate);
            fullscreenToggle.isOn = false;
        }
        else
        {
            for (int i = 1; i < Screen.resolutions.Length; i++)
            {
                if (Screen.resolutions[Screen.resolutions.Length - i].width % 16 == 0)
                {
                    Screen.SetResolution(Screen.resolutions[Screen.resolutions.Length - i].width, Screen.resolutions[Screen.resolutions.Length - i].height, true, refreshRate);
                    fullscreenToggle.isOn = true;
                }
                break;
            }
            
        }
    }

    public void VolumeChange()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
    }
}
