using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameters : MonoBehaviour
{
    public static GlobalParameters instance;
    public static GlobalParameters Instance { get { return instance; } }
    
    public LayerMask enemyLayer;
    public LayerMask itemLayer;
    public List<EnemyParameter> enemyStatuses;
    private Dictionary<string, EnemyStatus> listEnemies;
    private void Awake()
    {
        instance = this;
        listEnemies = new();
        foreach (var enemy in enemyStatuses)
        {
            listEnemies.Add(enemy.nameEnemy, enemy.enemyStatus);
        }
    }
    public EnemyStatus GetEnemy(string name)
    {
        if (listEnemies.TryGetValue(name, out EnemyStatus value))
        {
            return value;
        }
        else
        {
            Debug.LogError("Existn't enemy status with name " + name);
        }
        return null;
    }
}

[System.Serializable]
public class EnemyParameter
{
    public string nameEnemy;
    public EnemyStatus enemyStatus;
}