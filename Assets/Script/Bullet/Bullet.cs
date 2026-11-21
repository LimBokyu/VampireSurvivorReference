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

    public void Initialize(int pierce, int damage)
    {
        this.damage = damage;
        pierceCount = pierce;
    }

    public void SetDirection(Vector3 dir)
    {
        moveDir = dir;
    }

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


    private void OnTriggerEnter(Collider other)
    {
        //Wall 레이어마스크를 가진 오브젝트와 충돌 시 오브젝트 풀에 반환
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            pool.ReturnObject(gameObject);
        }

        //Enemy 레이어마스크를 가진 오브젝트와 충돌 시
        //EnemyComtroller 컴포넌트를 찾아 Bullet이 가진 Damage를 줌
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyController ec = null;
            ec = other.gameObject.GetComponentInParent<EnemyController>();

            if(ec != null)
                ec.GetDamaged(damage);


            if (pierceCount == 0)
            {
                pool.ReturnObject(gameObject);
            }
            else
                pierceCount--;
        }
    }
}
