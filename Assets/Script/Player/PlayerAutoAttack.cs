using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    [SerializeField]
    private float autoFireTimer = 1f;


    private float coolTime = 0f;

    private bool inRange = false;
    private bool inCoolTime = false;

    private float shootRange = 5f;

    [SerializeField]
    private LayerMask enemyMask;

    [SerializeField]
    private GameObject bulletObject;

    private Vector3 shootDir = Vector3.zero;

    [SerializeField]
    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        CheckEnemy();
        AutoFire();
        Test();
    }

    private void Test()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Collider[] col = Physics.OverlapSphere(transform.position, shootRange, enemyMask);

            if (col.Length == 0)
                return;

            Vector3 dir = (col[0].transform.position - transform.position).normalized;

            GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
            bullet.transform.forward = dir;
        }
    }

    public void ChangeCoolTime(float coolTime)
    {
        autoFireTimer = coolTime;
    }
        
    private void CheckEnemy()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, shootRange, enemyMask);

        Debug.Log(col.Length);

        if (col.Length == 0)
        {
            shootDir = Vector3.zero;
            inRange = false;
            return;
        }
        else
        {
            inRange = true;
            shootDir = (col[0].transform.position - transform.position).normalized;
        }
    }

    private void AutoFire()
    {
        if(inRange && !inCoolTime)
        {
            Shoot();
        }

        if(inCoolTime)
        {
            coolTime += Time.deltaTime;
            if(coolTime >= autoFireTimer)
            {
                coolTime = 0f;
                inCoolTime = false;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);

        bullet.transform.forward = shootDir;
        inCoolTime = true;
    }

}
