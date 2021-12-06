using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicController : MonoBehaviour
{
    [SerializeField] BackgroundMusic music;

    void Start()
    {
        music = GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<BackgroundMusic>();
        music.PlayAudio();
    }
}
