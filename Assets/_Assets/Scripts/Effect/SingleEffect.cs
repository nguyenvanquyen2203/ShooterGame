using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEffect : PoolObject
{
    public void ActiveEffect(Vector3 activePos)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
    }

    public override void OnCreate()
    {
        
    }
    private void OnDisable()
    {
        OwnerPool.ReturnToPool(this);
    }
}
