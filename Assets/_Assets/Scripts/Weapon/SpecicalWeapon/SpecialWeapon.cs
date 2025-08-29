using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialWeapon : PoolObject
{
    protected Vector3 targetPos;
    public virtual void ActiveSpWeapon(Vector3 activePos)
    {
        targetPos = activePos;
        gameObject.SetActive(true);
    }
}
