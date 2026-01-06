using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public void OnClicked()
    {
        GameManager.Instance.StartGameButtonClicked();
    }
}
