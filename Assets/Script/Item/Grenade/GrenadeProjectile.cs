using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeProjectile : MonoBehaviour
{
    enum GrenadeState { move, explosion }

    private GrenadeState state;

    [SerializeField]
    private int damage;

    [SerializeField]
    private Grenade grenade;

    [SerializeField]
    private float flyingDistance;

    private float moveDistance = 0f;

    [SerializeField]
    private float moveSpeed = 0.7f;

    [SerializeField]
    private LayerMask enemyLayer;

    [SerializeField]
    private float explosionRange;

    private void OnEnable()
    {
        SetDefault(); 
    }

    private void SetDefault()
    {
        moveDistance = 0f;
        state = GrenadeState.move;
    }

    private void Update()
    {
        switch (state)
        { 
            case GrenadeState.move:
                MovingGrenade();
                break;
            case GrenadeState.explosion:
                break;
        }
    }

    private void MovingGrenade()
    {
        moveDistance += moveSpeed * Time.deltaTime;
        transform.position += transform.forward * moveDistance;
        if(flyingDistance <= moveDistance)
        {
            state = GrenadeState.explosion;
            Explosion();
        }
    }

    private void Explosion()
    {
        Collider[] col = 
            Physics.OverlapSphere(
                transform.position, 
                explosionRange, 
                enemyLayer);

        foreach(Collider c in col)
        {
            EnemyController enemy = c.GetComponentInParent<EnemyController>();
            if(enemy != null)
            {
                enemy.GetDamaged(damage);
            }
        }

        Destroy(gameObject);
    }

    public void GetItemLevel(int itemLevel)
    {
        switch (itemLevel)
        {
            case 1:
            case 2:
                damage = 20;
                break;
            case 3:
            case 4:
                damage = 35;
                break;
            case 5:
                damage = 50;
                break;
            default:
                break;
        }

    }
}
