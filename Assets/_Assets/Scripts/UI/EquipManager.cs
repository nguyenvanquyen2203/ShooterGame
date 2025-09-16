using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public List<EquipLoad> equipBtn;
    public void ChangeWindow<T>(int numberEquipLoad, List<T> data) where T : OptionWeaponData
    {
        int numberEquip = 0;
        for (int i = 0; i < numberEquipLoad; i++)
        {
            equipBtn[i].gameObject.SetActive(true);
        } 
        for (int i = numberEquipLoad; i < equipBtn.Count; i++) equipBtn[i].gameObject.SetActive(false);
        int indexEquip = 0;
        for (int i = 0; i < data.Count; i++) 
        {
            T weapon = data[i];
            if (weapon.IsEquip())
            {
                numberEquip++;
                equipBtn[indexEquip++].SetWeaponEquip(weapon);
            }
        }
        for (int i = indexEquip; i < numberEquipLoad; i++)
        {
            equipBtn[i].ClearEquipLoad();
        }
        if (numberEquip == numberEquipLoad) OptionWindowManager.Instance.ClearEquipBtn();
    }
}
