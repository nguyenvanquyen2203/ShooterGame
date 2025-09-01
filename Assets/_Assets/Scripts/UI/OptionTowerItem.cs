using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTowerItem : OptionItem<OptionDefenderData>
{
    public override void BuyItem()
    {
        CoinManager.Instance.SpendCoin(data.buyCost);
        data.BuyItem();
        OptionWindowManager.Instance.ReloadWindow();
    }

    public override void ReloadOptionItem(int currentCoin)
    {
        if (data.buyCost <= 0) buyItemBtn.SetButton("Mounted", "", false);
        else buyItemBtn.SetButton("Buy", data.buyCost.ToString(), data.CheckBuyItem(currentCoin));
        upgradeBtn.SetButton("Upgrade", data.upgradeCost.ToString(), data.CheckUpgrade(currentCoin));
    }
}
