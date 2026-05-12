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

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            pool.ReturnObject(gameObject);

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyController ec = null;
            ec = other.gameObject.GetComponentInParent<EnemyController>();

            //Debug.Log(ec);
            if(ec != null)
                ec.GetDamaged(damage);


            if (pierceCount == 0)
            {
                //오브젝트 풀 이전의 코드
                //Destroy(this.gameObject);
                pool.ReturnObject(gameObject);
            }
            else
                pierceCount--;
        }
    }
}
