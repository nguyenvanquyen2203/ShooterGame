using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionDefenderData", fileName = "OptionDefenderData")]
public class OptionDefenderData : OptionItemData
{
    public float value;
    public int buyCost;
    public float bonusValue;
    public override void BuyItem()
    {
        currentLv++;
    }

    public override bool CheckBuyItem(int currentCoin)
    {
        if (buyCost > currentCoin) return false;
        return true;
    }
    public override void UpgradeItem()
    {
        base.UpgradeItem();
        value += bonusValue;
    }
}
