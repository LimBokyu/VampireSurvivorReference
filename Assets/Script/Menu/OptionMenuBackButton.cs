using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuBackButton : MonoBehaviour
{
    public void OnClicked()
    {
        GameManager.Instance.GetOptionManager().SelectBackButton();
    }
}
