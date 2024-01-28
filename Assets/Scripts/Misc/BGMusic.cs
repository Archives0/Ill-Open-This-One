using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    [SerializeField] AudioClip music;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        PlayMusic();
    }

    void PlayMusic()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(music);
        }
    }
}
