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

    [SerializeField]
    private EnemyType type;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        SetVital();

        navAgent.updateRotation = false;
        anim.SetBool("isMoving", true);
    }

    private void SetVital()
    {
        switch (type)
        {
            case EnemyType.A:
                enemyVital = 10 + (GameManager.Instance.GetRound() * 5);
                break;
            case EnemyType.B:
                enemyVital = 15 + (GameManager.Instance.GetRound() * 8);
                break;
            case EnemyType.C:
                enemyVital = 30 + (GameManager.Instance.GetRound() * 10);
                break;
            case EnemyType.D:
                enemyVital = (10 + (GameManager.Instance.GetRound() * 5))/2;
                break;
        }
    }

    private void LateUpdate()
    {
        navAgent.SetDestination(GameManager.Instance.GetPlayer().transform.position);
        Vector3 tempVec = (transform.position - GameManager.Instance.GetPlayer().transform.position).normalized;
        Vector3 dir = new Vector3(tempVec.x, 0f, tempVec.z);
        transform.forward = -dir;
            
    }

    public void GetDamaged(int damage)
    {
        enemyVital -= damage;
        if (enemyVital <= 0)
            Dead();

        //log.Append("EnemyGetDamaged : ");
        //log.Append(damage);
        //log.Append(" -> CurrentEnemyVital : ");
        //log.Append(enemyVital);
        //Debug.Log(log);
        //log.Clear();
    }

    private void Dead()
    {
        //Debug.Log("Enemy Dead");
        int random = Random.Range(0, 10);
        Vector3 dropPoint = new Vector3(transform.position.x, 1f, transform.position.z);
        if (random <= 8)
        {
            Instantiate(expObject, dropPoint, transform.rotation);
        }

        Destroy(gameObject);
    }

}
