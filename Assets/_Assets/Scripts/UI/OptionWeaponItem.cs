using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionWeaponItem : OptionItem<OptionWeaponData>
{
    public TextMeshProUGUI ammoText;
    public Button equipBtn;
    public override void ReloadOptionItem(int currentCoin)
    {
        if (data.IsEquip()) equipBtn.gameObject.SetActive(false);
        else equipBtn.gameObject.SetActive(true);
        ammoText.text = data.reserveAmmo.ToString();
        string buyContent = data.buyAmmoCost.ToString();
        
        if (data.IsFullAmmo()) buyContent = "MAX";
        buyItemBtn.SetButton("Buy Ammo" , buyContent, data.CheckBuyItem(currentCoin));

        string upgradeContent = data.upgradeCost.ToString();
        if (data.IsMaxLevel()) upgradeContent = "MAX";
        upgradeBtn.SetButton("Upgrade", upgradeContent, data.CheckUpgrade(currentCoin));
    }
    public void EquipWeapon()
    {
        data.EquipWeapon();
        OptionWindowManager.Instance.ReloadWindow();
    }

    public override void BuyItem()
    {
        CoinManager.Instance.SpendCoin(data.buyAmmoCost);
        data.BuyItem();
        OptionWindowManager.Instance.ReloadWindow();
    }
    public void RemoveEquipBtn()
    {
        equipBtn.gameObject.SetActive(false);
    }
}
