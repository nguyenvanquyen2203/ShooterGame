using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeIcon : MonoBehaviour
{
    public Image icon;
    public void Active(bool isUpgraded)
    {
        if (isUpgraded) icon.color = new Color(0f, 1f, 0f, 1f);
        else icon.color = new Color(1f, 1f, 0f, 1f);
    }
    public void Unactive()
    {
        icon.color = new Color(1f, 1f, 1f, 1f);
    }
}
