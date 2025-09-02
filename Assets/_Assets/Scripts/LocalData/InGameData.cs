using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData : MonoBehaviour
{
    private static InGameData instance;
    public static InGameData Instance { get { return instance; } }
    public List<GunInformation> gunEquips;
    public List<SpecialWeaponData> specialItemEquips;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set this as the Singleton instance
            instance = this;
            // Optional: Make the GameObject persistent across scenes
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        gunEquips = LocalData.Instance.GetGunList();
        specialItemEquips = LocalData.Instance.GetSpWeaponList();
    }
    public SpecialWeaponData GetSpWeapon(int index) => specialItemEquips[index]; 
    public void EquipGun(GunInformation gun) => gunEquips.Add(gun);
    public void UnequipGun(GunInformation gun) => gunEquips.Remove(gun);
    public void EquipSpWeapon(SpecialWeaponData spWeapon) => specialItemEquips.Add(spWeapon);
    public void UnequipSpWeapon(SpecialWeaponData spWeapon) => specialItemEquips.Remove(spWeapon);
}
