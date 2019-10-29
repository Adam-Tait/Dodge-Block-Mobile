using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{

    public AudioClip[] songs; //assign through inspector
    public int songNumber = 0;

    private AudioClip audio;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        audio = this.GetComponent<AudioClip>();
    }

    void Update()
    {
        StartAudio();
    }

    void StartAudio()
    {
        songNumber = Random.Range(0, songs.Length);
        if (audioSource.isPlaying == false)
        {
            songNumber++;

            if (songNumber >= songs.Length)
            {
                songNumber = 0;
                audio = songs[songNumber];
                audioSource.clip = audio;
                audioSource.Play();
            }
            else
            {
                audio = songs[songNumber];
                audioSource.clip = audio;
                audioSource.Play();
            }
        }
    }
}
