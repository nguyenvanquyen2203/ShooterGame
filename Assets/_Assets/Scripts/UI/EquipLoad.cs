using UnityEngine.UI;
using UnityEngine;

public class EquipLoad : MonoBehaviour
{
    public Button btn;
    private bool isEquip;
    public void SetWeaponEquip(Sprite sprite)
    {
        btn.image.sprite = sprite;
        isEquip = true;
        btn.gameObject.SetActive(true);
    }
    public void Unequip()
    {
        btn.gameObject.SetActive(false);
        isEquip = false;
    }
    public bool IsEquip() => isEquip;
}