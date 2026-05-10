using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVital : MonoBehaviour
{

    [SerializeField]
    private Slider hpBarSlider;

    [SerializeField]
    private int playerHP;
    private int playerMaxHP;

    private bool invincible = false;

    [SerializeField]
    private float invincibleTimer = 0.5f;

    private Vector3 offset = new Vector3(0f,0f,-1f);

    [SerializeField]
    private PlayerController playerController;

    private Coroutine InvincibilityCoroutine = null;

    private HitFlash flash;

    private void Awake()
    {
        flash = GetComponent<HitFlash>();
        SettingDefaultHP();
    }

    private void SettingDefaultHP()
    {
        playerHP = 500;
        playerMaxHP = 500;
        ChangeMaxHP(playerMaxHP);
        hpBarSlider.value = playerHP;
    }

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

    public void GetDamaged(int damage)
    {
        playerHP -= damage;
    }

    private IEnumerator InvinsibleCoroutine()
    {
        yield return new WaitForSeconds(invincibleTimer);
        InvincibilityCoroutine = null;
        invincible = false;
    }

    private void PlayerGetDamaged(int damage)
    {
        playerHP -= damage;
        hpBarSlider.value = playerHP;
        if(playerHP <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (invincible == true)
            return;

        EnemyController ec = other.gameObject.GetComponentInParent<EnemyController>();
        if (ec != null)
        {
            invincible = true;
            PlayerGetDamaged(ec.GetAttackDamage());
            flash.Flash();
            //Debug.Log("Player Get Damaged!");
            if (InvincibilityCoroutine == null)
            {
                InvincibilityCoroutine = StartCoroutine(InvinsibleCoroutine());
            }
        }
    }
}
