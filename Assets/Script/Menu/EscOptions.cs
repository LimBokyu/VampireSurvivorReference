using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSetting;
    private void Start()
    {
        gameObject.SetActive(false);
        gameSetting.SetActive(false);
    }
}
