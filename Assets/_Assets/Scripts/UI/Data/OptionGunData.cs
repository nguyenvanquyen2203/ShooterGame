using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionGunData", fileName = "OptionGunData")]
public class OptionGunData : OptionWeaponData
{
    public GunInformation gunInformation;
    public override void BuyItem()
    {
        gunInformation.reserveAmmo = Mathf.Clamp(gunInformation.reserveAmmo + gunInformation.magazineSize, 0, maxAmmo);
    }

    public override bool CheckBuyItem(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (gunInformation.reserveAmmo >= maxAmmo) return false;
        return true;
    }
    public override void EquipWeapon()
    {
        base.EquipWeapon();
        InGameData.Instance.EquipGun(gunInformation);
    }

    public override int GetReserve() => gunInformation.reserveAmmo;

    public override bool IsFullAmmo() => gunInformation.reserveAmmo >= maxAmmo;

    public override void UnequipWeapon()
    {
        base.UnequipWeapon();
        InGameData.Instance.UnequipGun(gunInformation);
    }
    public override void UpgradeItem()
    {
        base.UpgradeItem();
        if (currentLv <= 0) gunInformation.reserveAmmo += gunInformation.magazineSize;
    }
}
