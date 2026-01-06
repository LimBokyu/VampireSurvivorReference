using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.GetOptionManager().SetHelp(gameObject);
        gameObject.SetActive(false);
    }
}
