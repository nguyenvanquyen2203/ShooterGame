using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePotionExplosion : SpExplosion
{
    public override void ActiveExplosion(Vector3 activePos, float damage)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
    }

    public override void OnCreate()
    {
        
    }
}
