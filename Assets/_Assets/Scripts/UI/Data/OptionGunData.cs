using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionGunData", fileName = "OptionGunData")]
public class OptionGunData : OptionItemData
{
    private bool isEquip;
    public GunInformation gunInformation;

    public override void BuyAmmo()
    {
        throw new System.NotImplementedException();
    }
    public void Equip() => isEquip = true;
    public void Unequip() => isEquip = false;
    public bool IsEquip() => isEquip;
    
}
