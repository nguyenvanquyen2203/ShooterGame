using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : SpecialWeapon
{
    public override void ActiveSpWeapon(Vector3 activePos)
    {
        base.ActiveSpWeapon(activePos);
        transform.position = targetPos;
        WaveController.Instance.SetSnow(10f);
    }

    public override void OnCreate()
    {
        
    }
}
