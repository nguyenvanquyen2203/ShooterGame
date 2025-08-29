using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpExplosion : PoolObject
{
    public Vector2 boxSize;
    public abstract void ActiveExplosion(Vector3 activePos, float damage);
}
