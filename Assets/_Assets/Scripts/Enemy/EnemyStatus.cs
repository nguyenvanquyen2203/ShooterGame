using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy", fileName = "Monster")]
public class EnemyStatus : ScriptableObject
{
    public float moveSpeed;
    public int maxHp;
    public int damage;
    public int delayAttack;
    public float distanceAttack;
    [Header("Enemy prefabs")]
    public PoolObj<Enemy> enemyPool;
    public string GetNameEnemy() => enemyPool.poolName;
}
