using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "WaveData", fileName = "WaveData")]
public class WaveData : ScriptableObject
{
    public List<EnemySpawn> listEnemyPos;
}

[System.Serializable] 
public class EnemySpawn
{
    public string nameEnemy;
    public Vector3 position;
}