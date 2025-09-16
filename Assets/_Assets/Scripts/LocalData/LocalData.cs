using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalData : MonoBehaviour
{
    private static LocalData instance;
    public static LocalData Instance { get { return instance; } }

    public List<OptionGunData> gunDatas;
    public List<OptionSpecialData> itemDatas;
    public List<OptionDefenderData> towerDatas;

    public List<int> listNumberEquip;
    private void Awake()
    {
        instance = this;
    }
    public List<GunInformation> GetGunList()
    {
        List<GunInformation> listGun = new();
        foreach (var gun in gunDatas) if (gun.IsEquip()) listGun.Add(gun.gunInformation);
        return listGun;
    }
    public List<SpecialWeaponData> GetSpWeaponList()
    {
        List<SpecialWeaponData> listWeapon = new();
        foreach (var weapon in itemDatas) if (weapon.IsEquip()) listWeapon.Add(weapon.data);
        return listWeapon;
    }
}
