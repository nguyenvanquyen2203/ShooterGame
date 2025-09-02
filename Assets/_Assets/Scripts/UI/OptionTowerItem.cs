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
        if (data.currentLv <= 0)
        {
            buyItemBtn.SetButton("Buy", data.buyCost.ToString(), data.CheckBuyItem(currentCoin));
            upgradeBtn.SetButton("Upgrade", string.Empty, false);
        }
        else
        {
            buyItemBtn.SetButton("Mounted", "", false);
            upgradeBtn.SetButton("Upgrade", data.upgradeCost.ToString(), data.CheckUpgrade(currentCoin));
        }
    }
}
