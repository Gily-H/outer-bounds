using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Text volumeText;

    // Start is called before the first frame update
    void Start()
    {
        SetGameVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateVolumeText(float volume)
    {
        volume = volume * 100;
        volumeText.text = volume.ToString("0");
    }

    public void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat("VolumeValue", volumeSlider.value);
        SetGameVolume();
    }

    void SetGameVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
