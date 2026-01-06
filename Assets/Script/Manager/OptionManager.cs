using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{

    [SerializeField]
    private GameObject escOptions;

    [SerializeField]
    private GameObject optionMenu;

    [SerializeField]
    private GameObject mainOptions;

    [SerializeField]
    private GameObject helps;

    private bool optionsOpen = false;
    private bool isMainTitle;

    public void SetMenuOptions(GameObject obj)
    {
        optionMenu = obj;
    }

    public void SetMainOptions(GameObject obj)
    {
        mainOptions = obj;
    }

    public void SetHelp(GameObject obj)
    {
        helps = obj;
    }

    public void SelectOptions()
    {
        mainOptions.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void SelectBackButton()
    {
        mainOptions.SetActive(true);
        optionMenu.SetActive(false);
    }

    public void OpenHelps()
    {
        helps.SetActive(true);
    }

    public void CloseHelps()
    {
        helps.SetActive(false);
    }

    public void ShowOptions()
    {
        isMainTitle = SceneManager.GetActiveScene().name == "TitleScene" ? true : false;
        if (!isMainTitle)
        {
            optionsOpen = !optionsOpen;
            escOptions.SetActive(optionsOpen);
            GameManager.Instance.TimeControll(optionsOpen);
        }
    }

}
