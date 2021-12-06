using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicController : MonoBehaviour
{
    BackgroundMusic music;
    AudioSource endMusic;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<BackgroundMusic>();
        music.StopAudio();

        if (endMusic == null)
        {
            endMusic = GetComponent<AudioSource>();
        }
        AudioSource.PlayClipAtPoint(endMusic.clip, transform.position);
    }
}
