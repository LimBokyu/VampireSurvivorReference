using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{

    [SerializeField]
    private GameObject options;

    public void ShowOptions()
    {
        options.SetActive(true);
    }
}
