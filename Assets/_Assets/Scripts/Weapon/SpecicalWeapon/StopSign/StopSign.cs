using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopSign : SpecialWeapon
{
    public override void OnCreate()
    {
        
    }
    public override void ActiveSpWeapon(Vector3 activePos, float value)
    {
        GetComponent<StopSignDestroy>().SetHealth(value);
        base.ActiveSpWeapon(activePos, value);
    }
    private void OnEnable()
    {
        transform.position = Vector3.up * 6f + targetPos.x * Vector3.right;
        transform.DOMoveY(Random.Range(-3f, -2f), 1f).SetEase(Ease.InCubic);
    }    
}
