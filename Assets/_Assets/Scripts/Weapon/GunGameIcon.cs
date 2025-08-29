using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunGameIcon : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI reserveAmmoTxt;
    private Image background;
    private void Awake()
    {
        background = GetComponent<Image>();
    }
    public void ActiveGun() => background.color = new Color(0f, 1f, 0f);
    public void DisactiveGun() => background.color = new Color(1f, 1f, 1f);
    public void SetIcon(Sprite img, int reserveAmmo)
    {
        image.sprite = img;
        reserveAmmoTxt.text = reserveAmmo.ToString();
    }
}
