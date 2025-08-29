using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OptionItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int reserveAmmo; // Weapon
    public int maxAmmo; //Weapon
    public int currentLv;
    public int maxLevel;
    public int buyAmmoCost; //Weapon
    public int magazineSize; // Gun
    public int upgradeCost;
    public int upgradeIncrease;
    public int UpgradeItem(int currentCoin)
    {
        int tempCoin = currentCoin - upgradeCost;
        if (tempCoin >= 0)
        {
            currentLv++;
            upgradeCost += upgradeIncrease;
        }
        return tempCoin;
    }
    public bool CheckBuyAmmo(int currentCoin)
    {
        if (currentCoin < buyAmmoCost) return false;
        if (reserveAmmo >= maxAmmo) return false;
        return true;
    }
    public bool CheckUpgrade(int currentCoin)
    {
        if (currentCoin < upgradeCost) return false;
        if (currentLv >= maxLevel) return false;
        return true;
    }
    public abstract void BuyAmmo();
}
