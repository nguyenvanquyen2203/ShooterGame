using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunExplosion : PoolObject
{
    public void ActiveExplosion(Vector3 activePos)
    {
        float randomZAngle = Random.Range(0f, 360f);
        Vector3 randomEulerAngles = Vector3.zero;
        randomEulerAngles.z = randomZAngle;
        transform.eulerAngles = randomEulerAngles;
        transform.position = activePos;
        for (int i = 0; i < 5; i++)
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
