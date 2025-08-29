using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGroup : PoolObject
{
    public void ActiveExplosion(Vector3 activePos, int number)
    {
        transform.position = activePos;
        for (int i = 0; i < number; i++)
        {
            Vector3 randomVector = new Vector3(Random.Range(0f, 1.5f), Random.Range(-1f, 1f), 0f);
            BulletExplosion pool = PoolManager.Instance.Get<BulletExplosion>("BulletExplosionPool");
            pool.transform.position = transform.position + randomVector;
        }
    }

    public override void OnCreate()
    {
        
    }
}
