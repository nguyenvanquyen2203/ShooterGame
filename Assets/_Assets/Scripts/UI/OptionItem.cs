using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionItem : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI nameItemText;
    public Image itemImg;
    public CustomBtn buyAmmoBtn;
    public CustomBtn upgradeBtn;
    public Button equipBtn;
    private OptionItemData data;
    public virtual void SetOptionItem(OptionItemData _data, int currentCoin)
    {
        data = _data;
        itemImg.sprite = data.itemImage;
        nameItemText.text = data.itemName;
        ReloadOptionItem(currentCoin);
        gameObject.SetActive(true);
    }
    public void ReloadOptionItem(int currentCoin)
    {
        ammoText.text = data.reserveAmmo.ToString();
        buyAmmoBtn.SetButton(data.buyAmmoCost.ToString(), data.CheckBuyAmmo(currentCoin));
        upgradeBtn.SetButton(data.upgradeCost.ToString(), data.CheckUpgrade(currentCoin));
    }
    public void UpgradeItem()
    {
        
    }
}
