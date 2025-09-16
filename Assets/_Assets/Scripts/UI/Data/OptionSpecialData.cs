using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionSpecialData", fileName = "OptionSpecialData")]
public class OptionSpecialData : OptionWeaponData
{
    public SpecialWeaponData data;
    public override void BuyItem()
    {
        data.currentOwner++;
    }

    public override bool CheckBuyItem(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (data.currentOwner >= maxAmmo) return false;
        return true;
    }
    public override void EquipWeapon()
    {
        base.EquipWeapon();
        InGameData.Instance.EquipSpWeapon(data);
    }

    public override bool IsFullAmmo()
    {
        return data.currentOwner >= maxAmmo;
    }

    public override void UnequipWeapon()
    {
        base.UnequipWeapon();
        InGameData.Instance.UnequipSpWeapon(data);
    }
    public override int GetReserve() => data.currentOwner;
    public override void UpgradeItem()
    {
        base.UpgradeItem();
        if (currentLv <= 0) data.currentOwner++;
    }
}
