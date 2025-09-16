using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public List<UpgradeIcon> upgradeIcon;
    public void SetUpgradePanel(int currentLv,int maxLv)
    {
        for (int i = 0; i < maxLv; i++) upgradeIcon[i].gameObject.SetActive(true);
        for (int i = maxLv; i < upgradeIcon.Count; i++) upgradeIcon[i].gameObject.SetActive(false);
        for (int i = 0; i < currentLv; i++) upgradeIcon[i].Active(true);
        if (currentLv < maxLv) upgradeIcon[currentLv].Active(false);
        for (int i = currentLv + 1; i < maxLv; i++)
        {
            upgradeIcon[i].Unactive();
        }
    }
}
