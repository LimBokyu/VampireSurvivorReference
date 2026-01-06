using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenHelps : MonoBehaviour
{

    [SerializeField]
    private GameObject help;

    public void OnClicked()
    {
        help.SetActive(true);
        Debug.Log("OptionHelp Clicked");
    }
}
