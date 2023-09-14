using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SetLevelUpUI(gameObject);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
