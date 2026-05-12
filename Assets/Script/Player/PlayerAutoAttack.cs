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

    private Vector3 shootDir = Vector3.zero;

    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private BulletPool pool;

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

            // 오브젝트 풀 이전의 코드
            //GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
            //bullet.transform.forward = dir;

            GameObject bullet = pool.GetPoolObject();
            bullet.transform.position = gameObject.transform.position;
            bullet.GetComponent<Bullet>().SetDirection(dir);
            bullet.GetComponent<Bullet>().Initialize(controller.GetPlayerPierceCount(),controller.GetPlayerAttackDamage());
        }
    }

    public void ChangeCoolTime(float coolTime)
    {
        autoFireTimer = coolTime;
    }
        
    private void CheckEnemy()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, shootRange, enemyMask);

        if (col.Length == 0)
        {
            shootDir = Vector3.zero;
            inRange = false;
            return;
        }
        else
        {
            float nearDis = Vector3.Distance(col[0].transform.position, transform.position);
            int nearNum = 0;
            for(int index=1; index<col.Length; index++)
            {
                float compareDis = Vector3.Distance(col[index].transform.position, transform.position);
                if (nearDis > compareDis)
                {
                    nearDis = compareDis;
                    nearNum = index;
                }
                else
                    continue;
            }

            inRange = true;

            Vector3 vec = (col[nearNum].transform.position - transform.position).normalized;
            shootDir = new Vector3(vec.x, 0f, vec.z);
        }
    }

    private void AutoFire()
    {
        if(!inRange && !inCoolTime)
        {
            shootDir = transform.forward;
            Shoot();
        }
        else if(inRange && !inCoolTime)
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
        //오브젝트 풀 이전의 코드
        //GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
        //bullet.transform.forward = shootDir;

        GameObject bullet = pool.GetPoolObject();
        bullet.transform.position = gameObject.transform.position;
        bullet.GetComponent<Bullet>().SetDirection(shootDir);
        bullet.GetComponent<Bullet>().Initialize(controller.GetPlayerPierceCount(), controller.GetPlayerAttackDamage());
        inCoolTime = true;
    }

}
