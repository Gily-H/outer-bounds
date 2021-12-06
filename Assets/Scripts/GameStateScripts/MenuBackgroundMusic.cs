using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;

    private void Start()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = GetComponent<AudioSource>();
        }

        AudioSource.PlayClipAtPoint(backgroundMusic.clip, transform.position);
    }
}
