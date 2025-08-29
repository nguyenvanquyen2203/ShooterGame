using System.Collections.Generic;
using UnityEngine;

public class PoolController<T> : IObjectPool where T : PoolObject
{
    private Queue<T> _pool = new Queue<T>();
    private T _prefab;
    private string nameObject;
    private Transform _poolParent;

    public PoolController(T prefab, int initialSize, Transform parent, string nameObj)
    {
        _prefab = prefab;
        _poolParent = parent;
        nameObject = nameObj;

        // Pre-instantiate the initial number of objects.
        for (int i = 0; i < initialSize; i++)
        {
            T newObj = InstantiateAndDeactivate(nameObj);
            newObj.OnCreate();
            _pool.Enqueue(newObj);
        }
    }

    private T InstantiateAndDeactivate(string nameObj)
    {
        T newObj = GameObject.Instantiate(_prefab, _poolParent);
        newObj.OwnerPool = this; // Set the owner pool.
        newObj.SetNameObject(nameObj);
        newObj.OnReturnToPool(); // Deactivate it.
        return newObj;
    }

    // A generic method to get an object from the pool.
    public T GetFromPool()
    {
        T obj;
        if (_pool.Count > 0)
        {
            obj = _pool.Dequeue();
        }
        else
        {
            // If the pool is empty, create a new object.
            obj = InstantiateAndDeactivate(nameObject);
        }

        //obj.OnGetFromPool(); // Activate and initialize the object.
        return obj;
    }

    // A method to return an object to the pool.
    public void ReturnToPool(T obj)
    {
        obj.OnReturnToPool(); // Deactivate and reset.
        _pool.Enqueue(obj);
    }

    // Implementation of the non-generic interface method.
    public void ReturnToPool(IPoolable obj)
    {
        // We can safely cast because we know this pool only handles type T.
        if (obj is T castedObj)
        {
            ReturnToPool(castedObj);
        }
        else
        {
            Debug.LogError($"Attempted to return wrong type of object to the pool. Expected {typeof(T).Name}, got {obj.GetType().Name}");
        }
    }
}