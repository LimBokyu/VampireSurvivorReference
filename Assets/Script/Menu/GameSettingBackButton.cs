using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameSettingBackButton : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSetting;

    [SerializeField]
    private GameObject optionMenu;

    public void OnClicked()
    {
        gameSetting.SetActive(false);
        optionMenu.SetActive(true);
    }
}
