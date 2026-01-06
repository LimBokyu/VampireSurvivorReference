using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOptions : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.GetOptionManager().SetMainOptions(gameObject);
    }
}
