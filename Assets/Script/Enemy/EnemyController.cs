using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;
using Unity.VisualScripting;
using Cinemachine.Utility;

enum EnemyType { A, B, C, D }
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private int enemyVital;

    private StringBuilder log = new StringBuilder();

    [SerializeField]
    private GameObject expObject;

    private Animator anim;

    private PlayerController player;

    public float speed;

    private int damage;

    private HitFlash flash;

    [SerializeField]
    private EnemyType type;

    private void Awake()
    {
        //navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        SetEnemyValue();
        //navAgent.updateRotation = false;
        anim.SetBool("isMoving", true);
        flash = GetComponent<HitFlash>();
        player = GameManager.Instance.GetPlayer();
    }

    private void SetEnemyValue()
    {
        switch (type)
        {
            case EnemyType.A:
                enemyVital = 10 + (GameManager.Instance.GetRound() * 5);
                speed = 3.5f;
                damage = (20 + GameManager.Instance.GetRound() * 4);
                break;
            case EnemyType.B:
                enemyVital = 15 + (GameManager.Instance.GetRound() * 8);
                speed = 2f;
                damage = (30 + GameManager.Instance.GetRound() * 6);
                break;
            case EnemyType.C:
                enemyVital = 30 + (GameManager.Instance.GetRound() * 10);
                speed = 1f;
                damage = (50 + GameManager.Instance.GetRound() * 10);
                break;
            case EnemyType.D:
                enemyVital = (10 + (GameManager.Instance.GetRound() * 5)) / 2;
                speed = 5f;
                damage = (10 + GameManager.Instance.GetRound() * 2);
                break;
        }

        
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
            Dead();

        Debug.Log("Damaged");
        flash.Flash();

    }

    public int GetAttackDamage()
    {
        return damage;
    }

    private void Dead()
    {
        int random = Random.Range(0, 10);
        Vector3 dropPoint = new Vector3(transform.position.x, 1f, transform.position.z);
        if (random <= 8)
        {
            Instantiate(expObject, dropPoint, transform.rotation);
        }

        Destroy(gameObject);
    }

}
