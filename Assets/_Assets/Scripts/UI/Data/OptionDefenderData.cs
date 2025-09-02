using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionDefenderData", fileName = "OptionDefenderData")]
public class OptionDefenderData : OptionItemData
{
    public int buyCost;
    public override void BuyItem()
    {
        currentLv++;
    }

    public override bool CheckBuyItem(int currentCoin)
    {
        if (buyCost > currentCoin) return false;
        return true;
    }
}
