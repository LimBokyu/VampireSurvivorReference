using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    private float soundVolume;
    public void SetValue(float value)
    {
        soundVolume = value;
        GameManager.Instance.SetSFXVolume();
    }
}
