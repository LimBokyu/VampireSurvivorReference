using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int pierceCount;
    private int damage;

    [SerializeField]
    private float speed = 10;

    private BulletPool pool;

    private Vector3 moveDir;

    #region Bullet의 생성 후 방향, 관통력, 데미지, 오브젝트 풀 설정

    //데미지와 관통력을 받아오기 위한 함수
    public void Initialize(int pierce, int damage)
    {
        this.damage = damage;
        pierceCount = pierce;
    }

    //데미지와 관통력 전부 0으로 초기화
    public void SetDefault()
    {
        this.damage = 0;
        pierceCount = 0;
        moveDir     = Vector3.zero;
    }

    //방향 설정을 위한 함수
    public void SetDirection(Vector3 dir)
    {
        moveDir = dir;
    }


    //반환되어야할 오브젝트 풀을 받아오기 위한 함수
    public void SettingPool(BulletPool pool)
    {
        this.pool = pool;
    }

    #endregion

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void ReturnObject()
    {
        SetDefault();
        pool.ReturnObject(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Wall 레이어마스크를 가진 오브젝트와 충돌 시 오브젝트 풀에 반환
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            ReturnObject();
            return;
        }

        //Enemy 레이어마스크를 가진 오브젝트와 충돌 시
        //EnemyController 컴포넌트를 가지고 있는지 확인
        //가지고 있지 않다면 종료 가지고 있다면 타격 절차 진행
        //
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyController ec = null;
            ec = other.gameObject.GetComponentInParent<EnemyController>();

            if (ec == null)
            {
                return;
            }

            //EnemyController에 damage만큼의 피해를 줌
            ec.GetDamaged(damage);

            //관통력이 0에 도달했을 때 오브젝트 풀에 오브젝트를 반환
            //그것이 아니라면 관통력을 1감소
            if (pierceCount == 0)
            {
                ReturnObject();
            }
            else
                pierceCount--;
        }
    }
}
