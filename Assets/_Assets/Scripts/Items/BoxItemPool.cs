using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxItemPool : PoolObject
{
    // Start is called before the first frame update
    public void ActiveItem(Vector3 activePos)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
    }

    public override void OnCreate()
    {
        
    }
}
