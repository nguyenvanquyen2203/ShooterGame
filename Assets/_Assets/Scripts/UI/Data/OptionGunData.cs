using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionGunData", fileName = "OptionGunData")]
public class OptionGunData : OptionWeaponData
{
    public int magazineSize;
    public GunInformation gunInformation;
    public override void BuyItem()
    {
        reserveAmmo = Mathf.Clamp(reserveAmmo + magazineSize, 0, maxAmmo);
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
        InGameData.Instance.EquipGun(gunInformation);
    }
    public override void UnequipWeapon()
    {
        base.UnequipWeapon();
        InGameData.Instance.UnequipGun(gunInformation);
    }
}
