using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;
using Unity.VisualScripting;
using Cinemachine.Utility;

public enum EnemyType { A, B, C, D }
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    //private NavMeshAgent navAgent;
    private EnemyPool pool;

    private int enemyVital;
    private float dropYpoint = 1.0f;

    private StringBuilder log = new StringBuilder();

    [SerializeField]
    private GameObject expObject;

    private Animator anim;

    private PlayerController player;

    public float speed;

    private int damage;

    [SerializeField]
    private HitFlash flash;

    [SerializeField]
    private EnemyType type;

    //적 오브젝트 활성화시 디폴트 세팅 시작
    private void OnEnable()
    {
        SettingDefault();
    }

    //적의 디폴트 세팅
    //적 세부사항 세팅 및 플레이어 위치 확인을 위한 플레이어 컨트롤러 참조 획득
    private void SettingDefault()
    {
        anim = GetComponentInChildren<Animator>();
        SetEnemyValue();
        anim.SetBool("isMoving", true);
        player = GameManager.Instance.GetPlayer();
    }

    // 적 세부사항 세팅
    private void SetEnemyValue()
    {
        //적 라운드 진행에 따른 체력 세팅
        enemyVital 
            = enemyData.baseHP
            + (GameManager.Instance.GetRound() * enemyData.HPPerRound);

        //적 라운드 진행에 따른 데미지 세팅
        damage 
            = enemyData.baseDamage 
            + (GameManager.Instance.GetRound() * enemyData.damagePerRound);

        //적 종류별 속도 세팅
        speed = enemyData.moveSpeed;
    }

    private void LateUpdate()
    {
        //적 이동
        MoveEnemy();
    }

    //적 움직임 구현
    private void MoveEnemy()
    {
        //적 플레이어 위치를 기준으로 이동 방향 계산
        Vector3 dir = (player.gameObject.transform.position - transform.position).normalized;

        //적 진행방향으로 이동
        transform.position += new Vector3(dir.x, 0f, dir.z) * speed * Time.deltaTime;

        //적 플레이어 방향을 바라보게 설정
        transform.forward = dir;
    }

    //적 데미지 처리
    public void GetDamaged(int damage)
    {
        //적의 체력을 데미지 만큼 감소
        enemyVital -= damage;

        //적 체력이 0보다 작다면 사망 함수 호출 아닐 시 적이 점멸하는 효과 발생
        if (enemyVital <= 0)
        {
            Dead();
        }
        else
        {
            flash.Flash();
        }
    }


    //적이 가지고 있는 데미지 return
    public int GetAttackDamage()
    {
        return damage;
    }


    //
    public void SettingEnemyPool(EnemyPool pool)
    {
        this.pool = pool;
    }

    //적 사망시 처리
    private void Dead()
    {
        //랜덤으로 경험치 아이템 생성 확률 설정
        int random = Random.Range(0, 10);

        //경험치 아이템 생성 위치 설정
        Vector3 dropPoint = new Vector3(transform.position.x, dropYpoint, transform.position.z);

        //90% 확률로 경험치 아이템 생성
        if (random <= 8)
        {
            Instantiate(expObject, dropPoint, transform.rotation);
        }

        //오브젝트 풀에 적 반환
        pool.ReturnPoolObject(gameObject);
    }

}
