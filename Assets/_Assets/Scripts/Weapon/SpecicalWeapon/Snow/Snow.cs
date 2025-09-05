using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : SpecialWeapon
{
    public override void ActiveSpWeapon(Vector3 activePos, float value)
    {
        base.ActiveSpWeapon(activePos, value);
        transform.position = targetPos;
        WaveController.Instance.SetSnow(value);
    }

    public override void OnCreate()
    {
        
    }
}
