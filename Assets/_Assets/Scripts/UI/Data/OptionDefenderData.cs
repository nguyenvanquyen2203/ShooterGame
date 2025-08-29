using UnityEngine;
[CreateAssetMenu(menuName = "OptionItem/OptionDefenderData", fileName = "OptionDefenderData")]
public class OptionDefenderData : OptionItemData
{
    public override void BuyAmmo()
    {
        
    }

    public override bool CheckBuyAmmo(int currentCoin)
    {
        Debug.Log("Do check buy ammo in defender logic");
        return true;
    }
}
