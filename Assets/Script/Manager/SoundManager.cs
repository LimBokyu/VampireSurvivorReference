using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public enum SoundType { sfx, bgm }

    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource bgmSource;

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
    }

    public void SetSFXMuted(bool value)
    {
        isMutedSFX = value;
    }

    public void SetBGMMuted(bool value)
    {
        isMutedBGM = value;
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
