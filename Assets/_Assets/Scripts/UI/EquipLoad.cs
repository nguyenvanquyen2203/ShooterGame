using UnityEngine.UI;
using UnityEngine;

public class EquipLoad : MonoBehaviour
{
    public Button btn;
    public Image bg;
    private bool isEquip;
    private OptionWeaponData data;

    public void SetWeaponEquip(OptionWeaponData _data)
    {
        data = _data;
        bg.gameObject.SetActive(true);
        btn.image.sprite = data.itemImage;
        isEquip = true;
        btn.gameObject.SetActive(true);
    }
    public void ClearEquipLoad()
    {
        bg.gameObject.SetActive(false);
        btn.gameObject.SetActive(false);
        isEquip = false;
    }
    public void RemoveWeapon()
    {
        data.UnequipWeapon();
        OptionWindowManager.Instance.ReloadWindow();
    }
    public bool IsEquip() => isEquip;
}