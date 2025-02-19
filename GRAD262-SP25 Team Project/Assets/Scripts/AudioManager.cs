using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager instance;
    public AudioClip background;
    public AudioClip doorOpening;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ResumeBackground();
    }

    public void PlayDoorOpening()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = doorOpening;
        audio.loop = false;
        audio.Play();
        Invoke("ResumeBackground", audio.clip.length + 0.5f);
    }

    public void ResumeBackground()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = background;
        audio.loop = true;
        audio.Play();
    }

}
