using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialWeapon : PoolObject
{
    protected Vector3 targetPos;
    protected float value;
    public virtual void ActiveSpWeapon(Vector3 activePos, float value)
    {
        targetPos = activePos;
        this.value = value;
        //gameObject.SetActive(true);
    }
}
