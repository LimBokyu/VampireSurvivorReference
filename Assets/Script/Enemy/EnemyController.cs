using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Text;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private int enemyVital;

    private StringBuilder log = new StringBuilder();

    [SerializeField]
    private GameObject expObject;

    private Animator anim;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        enemyVital = 15;

        anim.SetBool("isMoving", true);
    }

    private void LateUpdate()
    {
        navAgent.SetDestination(GameManager.Instance.GetPlayer().transform.position);
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
