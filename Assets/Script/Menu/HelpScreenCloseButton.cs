using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenCloseButton : MonoBehaviour
{
    public void OnClicked()
    {
        //GameManager.Instance.GetOptionManager().CloseHelps();
        gameObject.SetActive(false);
    }
}
