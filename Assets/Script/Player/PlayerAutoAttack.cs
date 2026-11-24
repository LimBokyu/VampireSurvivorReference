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
    private float verDir = 0f;

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
    }

    //기본공격의 쿨타임 조정에 사용되는 함수
    public void ChangeCoolTime(float coolTime)
    {
        autoFireTimer = coolTime;
    }
        

    //적이 공격 범위 내로 들어왔는지 확인하여 기본공격의 방향을 설정하는 함수
    private void CheckEnemy()
    {
        //공격의 쿨타임 중이라면 함수 종료
        if (inCoolTime)
            return;

        //shootRange를 반경으로 삼는 원에 enemyMask를 가진 Collider가 있다면 col 배열에 추가
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

            Vector3 vec = (col[nearNum].transform.position - transform.position);
            shootDir = new Vector3(vec.x, verDir, vec.z).normalized;
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

    //발사 로직이 들어있는 함수
    private void Shoot()
    {
        //오브젝트 풀에서 오브젝트를 가져오고 Bullet 컴포넌트를 저장
        GameObject go = pool.GetPoolObject();
        Bullet bc = go.GetComponent<Bullet>();

        //가져온 오브젝트를 Player위치로 이동시키고 방향과 관통력 데미지 설정후 쿨타임ON
        go.transform.position = gameObject.transform.position;
        bc.SetDirection(shootDir);
        bc.Initialize(controller.GetPlayerPierceCount(), controller.GetPlayerAttackDamage());
        inCoolTime = true;
    }

}
