using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingOption : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSettings;
    
    public void ControlGameSettingOptions(bool active)
    {
        gameSettings.SetActive(active);
    }
}
