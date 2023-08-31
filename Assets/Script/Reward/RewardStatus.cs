using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardStatus
{ 
    private int damage;
    private int hp;
    private float attackCoolTime;
    private int pierceCount;
    public RewardStatus(int damage, int hp, float attackCoolTime, int pierce)
    {
        this.damage = damage;
        this.hp = hp;
        this.attackCoolTime = attackCoolTime;
        pierceCount = pierce;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetHP()
    {
        return hp;
    }

    public float GetAttackCoolTime()
    {
        return attackCoolTime;
    }

    public int GetPierceCount()
    {
        return pierceCount; 
    }

}
