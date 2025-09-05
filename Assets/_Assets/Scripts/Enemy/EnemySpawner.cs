using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get { return instance; } }
    public List<EnemyStatus> listEnemy;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        foreach (var enemy in listEnemy) PoolManager.Instance.CreatePool(enemy.enemyPool);
        
    }
    public EnemyStatus GetEnemyStatus(string nameEnemy)
    {
        foreach (var enemy in listEnemy)
        {
            if (enemy.enemyPool.poolName == nameEnemy) return enemy;
        }
        Debug.LogError($"Enemy with name {nameEnemy} does not exist in list Enemy of {gameObject.name}");
        return null;
    }
}
