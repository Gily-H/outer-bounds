using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (backgroundMusic == null)
        {
            backgroundMusic = GetComponent<AudioSource>();
        }
    }

    public void PlayAudio()
    {
        if (backgroundMusic.isPlaying)
        {
            return;
        }

        backgroundMusic.Play();
    }

    public void StopAudio()
    {
        backgroundMusic.Stop();
    }
}
