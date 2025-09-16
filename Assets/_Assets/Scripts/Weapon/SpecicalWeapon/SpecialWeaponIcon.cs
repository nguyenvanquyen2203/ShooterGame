using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialWeaponIcon : MonoBehaviour
{
    public Image icon;
    private Image bg;
    public Image cooldownImg;
    public TextMeshProUGUI txt;
    public void SetIcon(Sprite sprite, int number)
    {
        bg = GetComponent<Image>();
        icon.sprite = sprite;
        txt.text = number.ToString();
    }
    public void ReloadSpWeaponIcon(int newNumber)
    {
        txt.text = newNumber.ToString();
    }
    public void Active()
    {
        bg.color = Color.red;
    }
    public void Disactive()
    {
        bg.color = Color.white;
    }
    public void CooldownSpWeapon(float fillAmount)
    {
        cooldownImg.fillAmount = fillAmount;
    }
}
