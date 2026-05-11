using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public enum SoundType { sfx, bgm }

    private List<AudioSource> soundEffects;
    private List<AudioSource> backGroundMusic;
    private List<AudioSource> sources = new List<AudioSource>();

    private bool isMutedBGM = false;
    private bool isMutedSFX = false;

    [SerializeField]
    private float sfxVolume;

    [SerializeField]
    private float bgmVolume;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider bgmSlider;

    [SerializeField]
    private Toggle sfxMute;

    [SerializeField]
    private Toggle bgmMute;

    static private SoundManager instance;

    public SoundManager Instance
    {
        get { return instance; }

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        soundEffects = new List<AudioSource>();
        backGroundMusic = new List<AudioSource>();
    }

    public void SetSFXMuted()
    {
        isMutedSFX = sfxMute.isOn;
        SetSFXVolumeValue();
    }

    public void SetBGMMuted()
    {
        isMutedBGM = bgmMute.isOn;
        SetBGMVolumeValue(0f);
    }

    public void AddSFX(AudioSource clip)
    {
        soundEffects.Add(clip);
    }

    public void AddBGM(AudioSource clip)
    {
        backGroundMusic.Add(clip);
    }

    public void SetSFXVolumeValue()
    {
        foreach (AudioSource audio in soundEffects)
        {
            audio.volume = isMutedSFX ? 0f : sfxSlider.value;
        }
    }

    public void SetBGMVolumeValue(float value)
    {
        foreach (AudioSource audio in backGroundMusic)
        {
            audio.volume = isMutedBGM ? 0f : bgmSlider.value;
        }
    }

    public float ObjectSettingVolume(SoundType type)
    {
        float returnVolume;

        switch (type)
        {
            case SoundType.bgm:
                returnVolume = bgmVolume;
                break;
            case SoundType.sfx:
                returnVolume = sfxVolume;
                break;
            default:
                returnVolume = 0f;
                break;
        }

        return returnVolume;
    }
}
