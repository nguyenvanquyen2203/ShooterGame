using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : PlayerHealth
{
    private static PlayerTower instance;
    public static PlayerTower Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    public override void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
