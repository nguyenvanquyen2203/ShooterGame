using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class OptionItem<T> : MonoBehaviour where T : OptionItemData
{
    public TextMeshProUGUI nameItemText;
    public Image itemImg;
    public CustomBtn buyAmmoBtn;
    public CustomBtn upgradeBtn;
    protected T data;
    public void SetOptionItem(T _data, int currentCoin)
    {
        data = _data;
        itemImg.sprite = data.itemImage;
        nameItemText.text = data.itemName;
        ReloadOptionItem(currentCoin);
        gameObject.SetActive(true);
    }
    public abstract void ReloadOptionItem(int currentCoin);
    /*{
        if (data.buyAmmoCost == 0) buyAmmoBtn.SetMaxButton("Mounted", data.CheckBuyAmmo(currentCoin));
        else buyAmmoBtn.SetButton(data.buyAmmoCost.ToString(), data.CheckBuyAmmo(currentCoin));
        upgradeBtn.SetButton(data.upgradeCost.ToString(), data.CheckUpgrade(currentCoin));
    }*/
    public virtual void UpgradeItem()
    {
        
    }
    /*public virtual void BuyAmmo()
    {
        data.buyAmmoCost = 0;
    }*/
}
