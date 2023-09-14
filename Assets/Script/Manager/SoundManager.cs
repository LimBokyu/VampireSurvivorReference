using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private List<AudioSource> soundEffects;
    private List<AudioSource> backGroundMusic;
    private List<AudioSource> sources = new List<AudioSource>();

    private void Awake()
    {
        soundEffects = new List<AudioSource>();
        backGroundMusic = new List<AudioSource>();
    }

    public void AddSFX(AudioSource clip)
    {
        soundEffects.Add(clip);
    }

    public void SetVolumeValue(float value, bool isBGM)
    {
        sources = isBGM ? backGroundMusic : soundEffects;
        foreach (AudioSource audio in sources)
        {
            audio.volume = value;
        }
    }
}
