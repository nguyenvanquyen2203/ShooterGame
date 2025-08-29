using UnityEngine;
public interface IPoolable
{
    // Called when the object is taken from the pool.
    void OnGetFromPool();

    // Called when the object is returned to the pool.
    void OnReturnToPool();
}