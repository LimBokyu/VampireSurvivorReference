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
    private NavMeshAgent navAgent;
    private EnemyPool pool;

    private int enemyVital;

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

    private void OnEnable()
    {
        SetEnemyValue();
        SettingDefault();
    }

    private void SettingDefault()
    {
        anim = GetComponentInChildren<Animator>();
        SetEnemyValue();
        anim.SetBool("isMoving", true);
        player = GameManager.Instance.GetPlayer();
    }

    private void SetEnemyValue()
    {
        enemyVital 
            = enemyData.baseHP
            + (GameManager.Instance.GetRound() * enemyData.HPPerRound);

        damage 
            = enemyData.baseDamage 
            + (GameManager.Instance.GetRound() * enemyData.damagePerRound);

        speed = enemyData.moveSpeed;
    }

    private void LateUpdate()
    {
        //navAgent.SetDestination(GameManager.Instance.GetPlayer().transform.position);
        //Vector3 tempVec = (transform.position - GameManager.Instance.GetPlayer().transform.position).normalized;
        //Vector3 dir = new Vector3(tempVec.x, 0f, tempVec.z);
        //transform.forward = -dir;
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 dir = (player.gameObject.transform.position - transform.position).normalized;
        transform.position += new Vector3(dir.x, 0f, dir.z) * speed * Time.deltaTime;
        transform.forward = dir;
    }

    public void GetDamaged(int damage)
    {
        enemyVital -= damage;
        if (enemyVital <= 0)
        {
            Dead();
        }
        else
        {
            flash.Flash();
        }
    }

    public int GetAttackDamage()
    {
        return damage;
    }

    public void SettingEnemyPool(EnemyPool pool)
    {
        this.pool = pool;
    }

    private void Dead()
    {
        int random = Random.Range(0, 10);
        Vector3 dropPoint = new Vector3(transform.position.x, 1f, transform.position.z);
        if (random <= 8)
        {
            Instantiate(expObject, dropPoint, transform.rotation);
        }

        pool.ReturnPoolObject(gameObject);
        //Destroy(gameObject);
    }

}
