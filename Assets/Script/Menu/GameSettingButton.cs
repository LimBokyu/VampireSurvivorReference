using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingButton : MonoBehaviour
{

    [SerializeField]
    private GameObject gameSetting;
    [SerializeField]
    private GameObject optionsMenu;
    public void OnClicked()
    {
        optionsMenu.SetActive(false);
        gameSetting.SetActive(true);
        Debug.Log("°«´ï");
    }
}
