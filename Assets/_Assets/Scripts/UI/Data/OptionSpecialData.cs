using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionSpecialData", fileName = "OptionSpecialData")]
public class OptionSpecialData : OptionWeaponData
{
    public override void BuyAmmo()
    {
        
    }

    public override bool CheckBuyAmmo(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (reserveAmmo >= maxAmmo) return false;
        return true;
    }
}
