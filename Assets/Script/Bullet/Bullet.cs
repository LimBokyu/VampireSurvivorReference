using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int pierceCount;
    private int damage;
    private float speed;

    private void Awake()
    {
        damage = GameManager.Instance.GetPlayer().GetPlayerAttackDamage();
        pierceCount = GameManager.Instance.GetPlayer().GetPlayerPierceCount();
        speed = 10f;
    }

    public void SetDirection(Vector3 dir)
    {
        transform.forward = dir;
        //Debug.Log(dir);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Wall"))
            Destroy(gameObject);

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyController ec = null;
            ec = other.gameObject.GetComponentInParent<EnemyController>();

            //Debug.Log(ec);
            if(ec != null)
                ec.GetDamaged(damage);


            if (pierceCount == 0)
            {
                Destroy(this.gameObject);
            }
            else
                pierceCount--;
        }
    }
}
