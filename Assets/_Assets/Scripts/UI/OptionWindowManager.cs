using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionWindowManager : MonoBehaviour
{
    public OptionTowerItem towerItemPrefab;
    public OptionWeaponItem weaponItemPrefab;
    public EquipManager equipManager;
    public int number;
    public Transform parent;
    [Header("Option Item Data")]
    public List<OptionGunData> gunDatas;
    public List<OptionSpecialData> itemDatas;
    public List<OptionDefenderData> towerDatas;
    public List<int> listNumberEquip;
    private List<OptionTowerItem> optionTowerItems;
    private List<OptionWeaponItem> optionWeaponItems;
    // Start is called before the first frame update
    private void Awake()
    {
        optionTowerItems = new();
        for (int i = 0; i < number; i++)
        {
            var newObj = Instantiate(towerItemPrefab, parent);
            newObj.gameObject.SetActive(false);
            optionTowerItems.Add(newObj);
        }
        optionWeaponItems = new();
        for (int i = 0; i < number; i++)
        {
            var weaponObj = Instantiate(weaponItemPrefab, parent);
            weaponObj.gameObject.SetActive(false);
            optionWeaponItems.Add(weaponObj);
        }
    }
    private void OnEnable()
    {
        
    }
    public void SetWindowData(int index)
    {
        equipManager.ChangeWindow(listNumberEquip[index]);
        if (index == 0)
        {
            for (int i = 0; i < gunDatas.Count; i++)
            {
                var gunData = gunDatas[i];
                optionWeaponItems[i].SetOptionItem(gunData, 1000);
            }
            for (int i = gunDatas.Count; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);

            for (int i = 0; i < towerDatas.Count; i++) optionTowerItems[i].gameObject.SetActive(false);
        }
        if (index == 1)
        {
            for (int i = 0; i < itemDatas.Count; i++)
            {
                optionWeaponItems[i].SetOptionItem(itemDatas[i], 1000);
            }
            for (int i = itemDatas.Count; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);

            for (int i = 0; i < towerDatas.Count; i++) optionTowerItems[i].gameObject.SetActive(false);
        }
        if (index == 2)
        {
            for (int i = 0; i < towerDatas.Count; i++)
            {
                optionTowerItems[i].SetOptionItem(towerDatas[i], 1000);
            }
            for (int i = towerDatas.Count; i < optionTowerItems.Count; i++) optionTowerItems[i].gameObject.SetActive(false);

            for (int i = 0; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);
        }
    }
}