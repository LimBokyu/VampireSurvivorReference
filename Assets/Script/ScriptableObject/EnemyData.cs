using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Type")]
    [Space]
    public EnemyType enemyType;

    [Header("Enemy Damage")]
    [Space]
    public int baseDamage;

    public int damagePerRound;


    [Header("Enemy HP")]
    [Space]
    public int baseHP;

    public int HPPerRound;

    [Header("Enemy Speed")]
    [Space]
    public float moveSpeed;
}
