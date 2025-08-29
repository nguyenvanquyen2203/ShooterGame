using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour, IObjectPool
{
    void IObjectPool.ReturnToPool(IPoolable obj)
    {
        throw new System.NotImplementedException();
    }
}
