using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class OptionItem<T> : MonoBehaviour where T : OptionItemData
{
    public TextMeshProUGUI nameItemText;
    public Image itemImg;
    public CustomBtn buyItemBtn;
    public CustomBtn upgradeBtn;
    public UpgradePanel upgradePanel;
    public ItemImageInteraction itemImageInteratable;
    
    protected T data;
    public void SetOptionItem(T _data, int currentCoin)
    {
        data = _data;
        itemImg.sprite = data.itemImage;
        nameItemText.text = data.itemName;
        upgradePanel.SetUpgradePanel(data.currentLv, data.maxLevel);
        itemImageInteratable.Set(data.itemImage, data.itemName, data.description);
        ReloadOptionItem(currentCoin);
        gameObject.SetActive(true);
    }
    public abstract void ReloadOptionItem(int currentCoin);
    public virtual void UpgradeItem()
    {
        CoinManager.Instance.SpendCoin(data.upgradeCost);
        AudioManager.Instance.PlaySFX("Upgrade");
        data.UpgradeItem();
        OptionWindowManager.Instance.ReloadWindow();
    }
    public abstract void BuyItem();
}
