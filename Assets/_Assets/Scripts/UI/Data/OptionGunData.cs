using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionGunData", fileName = "OptionGunData")]
public class OptionGunData : OptionWeaponData
{
    public int magazineSize;
    public GunInformation gunInformation;
    public override void BuyAmmo()
    {
        
    }
    public void Equip() => isEquip = true;
    public void Unequip() => isEquip = false;
    public bool IsEquip() => isEquip;

    public override bool CheckBuyAmmo(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (reserveAmmo >= maxAmmo) return false;
        return true;
    }
}
