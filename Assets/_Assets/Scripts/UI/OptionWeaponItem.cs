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
        ammoText.text = data.reserveAmmo.ToString();
        buyAmmoBtn.SetButton(data.buyAmmoCost.ToString(), data.CheckBuyAmmo(currentCoin));
        upgradeBtn.SetButton(data.upgradeCost.ToString(), data.CheckUpgrade(currentCoin));
    }
    public override void UpgradeItem()
    {

    }
}
