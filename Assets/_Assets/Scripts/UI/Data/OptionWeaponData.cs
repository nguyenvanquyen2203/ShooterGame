using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OptionWeaponData : OptionItemData
{
    protected bool isEquip;
    public int reserveAmmo;
    public int maxAmmo;
    public int buyAmmoCost;
    public bool IsEquip() => isEquip;
    public void EquipWeapon() => isEquip = true;
    public void UnequipWeapon() => isEquip = false;
    public bool IsFullAmmo() => reserveAmmo >= maxAmmo;
}
