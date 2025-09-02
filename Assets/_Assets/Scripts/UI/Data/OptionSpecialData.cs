using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionSpecialData", fileName = "OptionSpecialData")]
public class OptionSpecialData : OptionWeaponData
{
    public SpecialWeaponData data;
    public override void BuyItem()
    {
        reserveAmmo++;
    }

    public override bool CheckBuyItem(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (reserveAmmo >= maxAmmo) return false;
        return true;
    }
    public override void EquipWeapon()
    {
        base.EquipWeapon();
        InGameData.Instance.EquipSpWeapon(data);
    }
    public override void UnequipWeapon()
    {
        base.UnequipWeapon();
        InGameData.Instance.UnequipSpWeapon(data);
    }
}
