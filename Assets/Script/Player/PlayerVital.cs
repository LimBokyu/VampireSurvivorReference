using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVital : MonoBehaviour
{

    [SerializeField]
    private Slider hpBarSlider;

    private Vector3 offset = new Vector3(0f,0f,-1f);

    [SerializeField]
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameManager.Instance.GetPlayer();
    }
    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        //transform.position = Camera.main.WorldToScreenPoint(playerController.gameObject.transform.position - offset);
    }

    public void SetCurrentHP()
    {
        
    }

    public void ChangeMaxHP(float value)
    {
        hpBarSlider.maxValue = value;
    }
}
