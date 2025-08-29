using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OptionWeaponData : OptionItemData
{
    protected bool isEquip;
    public int reserveAmmo;
    public int maxAmmo;
    public int buyAmmoCost;
    public override void BuyAmmo()
    {
        throw new System.NotImplementedException();
    }

    
}
