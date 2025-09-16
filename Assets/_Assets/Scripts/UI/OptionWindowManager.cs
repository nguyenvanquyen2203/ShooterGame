using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionWindowManager : MonoBehaviour
{
    private static OptionWindowManager instance;
    public static OptionWindowManager Instance { get { return instance; } }
    public TextMeshProUGUI coinTxt;
    public OptionTowerItem towerItemPrefab;
    public OptionWeaponItem weaponItemPrefab;
    public EquipManager equipManager;
    public int number;
    public Transform parent;

    private List<OptionGunData> gunDatas;
    private List<OptionSpecialData> itemDatas;
    private List<OptionDefenderData> towerDatas;
    private List<int> listNumberEquip;
    private List<OptionTowerItem> optionTowerItems;
    private List<OptionWeaponItem> optionWeaponItems;

    public DescriptionPanel descriptionPanel;
    private int indexPage;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
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
        gunDatas = LocalData.Instance.gunDatas;
        itemDatas = LocalData.Instance.itemDatas;
        towerDatas = LocalData.Instance.towerDatas;
        listNumberEquip = LocalData.Instance.listNumberEquip;
    }
    public void SetWindowData(int index)
    {
        indexPage = index;
        if (index == 0)
        {
            for (int i = 0; i < gunDatas.Count; i++)
            {
                var gunData = gunDatas[i];
                optionWeaponItems[i].SetOptionItem(gunData, CoinManager.Instance.GetCoin());
            }
            for (int i = gunDatas.Count; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);

            for (int i = 0; i < towerDatas.Count; i++) optionTowerItems[i].gameObject.SetActive(false);
            equipManager.ChangeWindow(listNumberEquip[index],gunDatas);
        }
        if (index == 1)
        {
            for (int i = 0; i < itemDatas.Count; i++)
            {
                optionWeaponItems[i].SetOptionItem(itemDatas[i], CoinManager.Instance.GetCoin());
            }
            for (int i = itemDatas.Count; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);

            for (int i = 0; i < towerDatas.Count; i++) optionTowerItems[i].gameObject.SetActive(false);
            equipManager.ChangeWindow(listNumberEquip[index], itemDatas);
        }
        if (index == 2)
        {
            for (int i = 0; i < towerDatas.Count; i++)
            {
                optionTowerItems[i].SetOptionItem(towerDatas[i], CoinManager.Instance.GetCoin());
            }
            for (int i = towerDatas.Count; i < optionTowerItems.Count; i++) optionTowerItems[i].gameObject.SetActive(false);

            for (int i = 0; i < optionWeaponItems.Count; i++) optionWeaponItems[i].gameObject.SetActive(false);
            equipManager.ChangeWindow(listNumberEquip[index], itemDatas);
        }
    }
    public void ReloadWindow()
    {
        SetWindowData(indexPage);
    }
    public void ClearEquipBtn()
    {
        if (indexPage == 0)
            for (int i = 0; i < gunDatas.Count; i++) optionWeaponItems[i].RemoveEquipBtn();
        if (indexPage == 1)
            for (int i = 0; i < itemDatas.Count; i++) optionWeaponItems[i].RemoveEquipBtn();
    }
    public void ShowDescriptionPanel(Sprite sprite, string namePanel, string description)
    {
        descriptionPanel.ActiveDescription(sprite, namePanel, description);
    }
    private void OnEnable()
    {
        coinTxt.text = CoinManager.Instance.GetCoin().ToString();
    }
    public void SetCoinText(int currentCoin) => coinTxt.text = currentCoin.ToString();
}