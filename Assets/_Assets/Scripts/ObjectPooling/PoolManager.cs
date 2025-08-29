using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // A singleton instance for easy access.
    private static PoolManager instance;
    public static PoolManager Instance { get { return instance; } }

    // The dictionary that holds all our different pools.
    private Dictionary<string, IObjectPool> _pools = new Dictionary<string, IObjectPool>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use a generic method to create and register a new pool.
    /*public void CreatePool<T>(T prefab, int initialSize, string poolName) where T : PoolObject
    {
        if (_pools.ContainsKey(poolName))
        {
            Debug.LogWarning($"A pool with the name '{poolName}' already exists.");
            return;
        }

        // Create a parent transform in the hierarchy for organization.
        GameObject poolParent = new GameObject(poolName);
        poolParent.transform.SetParent(transform);

        // Create the generic PoolController.
        PoolController<T> newPool = new PoolController<T>(prefab, initialSize, poolParent.transform);
        _pools.Add(poolName, newPool);
    }*/

    public void CreatePool<T>(PoolObj<T> pool) where T : PoolObject
    {
        if (_pools.ContainsKey(pool.poolName))
        {
            Debug.LogWarning($"A pool with the name '{pool.poolName}' already exists.");
            return;
        }

        // Create a parent transform in the hierarchy for organization.
        GameObject poolParent = new GameObject(pool.poolName);
        poolParent.transform.SetParent(transform);

        // Create the generic PoolController.
        PoolController<T> newPool = new PoolController<T>(pool.prefab, pool.initialSize, poolParent.transform, pool.poolName);
        _pools.Add(pool.poolName, newPool);
    }

    // Use a generic method to get an object from a specific pool.
    public T Get<T>(string poolName) where T : PoolObject
    {
        if (_pools.TryGetValue(poolName, out IObjectPool pool))
        {
            if (pool is PoolController<T> genericPool)
            {
                return genericPool.GetFromPool();
            }
            else
            {
                Debug.LogError($"Pool '{poolName}' exists but is not of the correct type ({typeof(T).Name}).");
                return null;
            }
        }

        Debug.LogError($"Pool with name '{poolName}' does not exist.");
        return null;
    }
}

[System.Serializable]
public class PoolObj<T> where T : PoolObject
{
    public string poolName;
    public T prefab;
    public int initialSize;
}