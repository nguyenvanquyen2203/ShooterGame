using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OptionWeaponData : OptionItemData
{
    protected bool isEquip;
    //public int reserveAmmo;
    public int maxAmmo;
    public int buyAmmoCost;
    public bool IsEquip() => isEquip;
    public virtual void EquipWeapon() => isEquip = true;
    public virtual void UnequipWeapon() => isEquip = false;
    public abstract bool IsFullAmmo();
    public abstract int GetReserve();
}
