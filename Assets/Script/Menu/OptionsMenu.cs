using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.GetOptionManager().SetMenuOptions(gameObject);
        gameObject.SetActive(false);
    }
}
