using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StopSign : SpecialWeapon
{
    public override void OnCreate()
    {
        
    }

    private void OnEnable()
    {
        transform.position = Vector3.up * 6f + targetPos.x * Vector3.right;
        transform.DOMoveY(Random.Range(-2f,-1f), 1f).SetEase(Ease.InCubic);
    }    
}
