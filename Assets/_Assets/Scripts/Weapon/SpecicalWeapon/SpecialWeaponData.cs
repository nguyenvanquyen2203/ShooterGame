using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpecialWeapon", fileName = "SpecialWeapon")]
public class SpecialWeaponData : ScriptableObject
{
    public string nameWeapon;
    public int currentOwner;
    public float value;
    public Sprite icon;
    public void SetGunInfo(string nameWeapon, Sprite icon, float value, int currentOwner, int maxOwner)
    {
        this.nameWeapon = nameWeapon;
        this.icon = icon;
        this.value = value;
        this.currentOwner = currentOwner;
    }
}
