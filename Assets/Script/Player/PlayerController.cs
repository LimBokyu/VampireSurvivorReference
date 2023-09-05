using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

enum PlayerState { idle, daed }

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Slider expUI;

    [SerializeField]
    private PlayerAutoAttack autoAttack = null;

    private CharacterController controller = null;

    private PlayerState state;
    private Vector3 mousePos;
    private Rigidbody rigid;
    private Animator anim;
    private bool banControl = false;

    [Space]
    [SerializeField] private int exp;
    [SerializeField] private int level;
    [SerializeField] private int maxEXP;

    [SerializeField] private int damage;
    [SerializeField] private float attackCoolTime;
    [SerializeField] private int hp;
    private int maxhp;
    [SerializeField] private int pierceCount;

    private void Awake()
    {
        state = PlayerState.idle;
        rigid = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        anim = GetComponentInChildren<Animator>();
        autoAttack = GetComponent<PlayerAutoAttack>();
        controller = GetComponent<CharacterController>();

        GameManager.Instance.SetPlayerController(this);

        SetDefault();
    }

    private void SetDefault()
    {
        exp = 0;
        level = 1;
        maxEXP = 100;

        hp = 100;
        maxhp = 100;
        damage = 10;
        attackCoolTime = 1f;
        pierceCount = 3;

        SetEXPUI();
    }

    private void SetEXPUI()
    {
        expUI.maxValue = maxEXP;
        expUI.value = exp;
    }

    public void EXPUp(int exp)
    {
       this.exp += exp;
        if(maxEXP <= this.exp)
        {
            int overEXP = this.exp - maxEXP;
            LevelUp(overEXP);
        }

        SetEXPUI();
    }

    private void LevelUp(int overEXP)
    {
        level++;
        maxEXP += (level * 20);
        exp = overEXP;
        GameManager.Instance.TimeControll(true);
        GameManager.Instance.ShowLevelUpReward();
    }

    public void PlayerGetDamaged(int damaged)
    {
        hp -= damaged;
        if (hp <= 0)
            PlayerDead();
    }
    private void Update()
    {
        if (banControl == true)
            return;

        switch (state)
        {
            case PlayerState.idle:
                PlayerMove();
                break;
            case PlayerState.daed:
                break;
        }

        GetMousePosition();
        LevelTest();
    }

    private void LevelTest()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            EXPUp(50);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            // 레벨업 테스트용
            EXPUp(maxEXP);
        }
    }

    private void PlayerMove()
    {
        float vAxis;
        float hAxis;

        vAxis = Input.GetAxisRaw("Vertical");
        hAxis = Input.GetAxisRaw("Horizontal");

        Vector3 moveVec = new Vector3(-hAxis, 0f,-vAxis).normalized;

        bool isMoving = moveVec.sqrMagnitude != 0f ? true : false;
        //Debug.Log(isMoving);
        anim.SetBool("isMoving", isMoving);
        if(moveVec != Vector3.zero)
            transform.forward = Vector3.Lerp(transform.forward, moveVec, 0.5f);

        //float maxSpeed = 10f;
        //if(rigid.velocity.magnitude > maxSpeed)
        //    rigid.velocity = rigid.velocity.normalized * maxSpeed;

        controller.Move(moveVec * moveSpeed * Time.deltaTime);
    }

    private void PlayerDead()
    {

    }

    private void GetMousePosition()
    {
    }

    public int GetPlayerAttackDamage()
    {
        return damage;
    }

    public int GetPlayerPierceCount()
    {
        return pierceCount;
    }
    
    public void ControlRestored()
    {
        banControl = false;
    }

    public void PlayerGetReward(RewardStatus status)
    {
        damage += status.GetDamage();
        hp += status.GetHP();
        maxhp += status.GetHP();
        attackCoolTime -= status.GetAttackCoolTime();
        pierceCount += status.GetPierceCount();
            
        autoAttack.ChangeCoolTime(attackCoolTime);
    }
}
