using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialManager : MonoBehaviour
{
    public List<SpecialWeaponIcon> listIcon;
    private List<SpecialWeaponData> listSpecicalWeaponData;    

    private int currentSpWeapon;
    private void Awake()
    {
        currentSpWeapon = 0;
    }
    private void Start()
    {
        listSpecicalWeaponData = InGameData.Instance.specialItemEquips;
        for (int i = 0; i < listSpecicalWeaponData.Count; i++)
        {
            listIcon[i].SetIcon(listSpecicalWeaponData[i].icon, listSpecicalWeaponData[i].currentOwner);
        }
        for (int i = listSpecicalWeaponData.Count; i < listIcon.Count; i++) listIcon[i].gameObject.SetActive(false);
    }
    public void ActiveSpWeapon(int index)
    {
        if (currentSpWeapon != 0) listIcon[currentSpWeapon - 1].Disactive();
        currentSpWeapon = index;
        listIcon[currentSpWeapon - 1].Active();
    }
    public void DisaciveSpWeapon()
    {
        listIcon[currentSpWeapon - 1].Disactive();
        currentSpWeapon = 0;
    }
    public void UseSpWeapon(int index, Vector3 activePos)
    {
        SpecialWeapon spItem = PoolManager.Instance.Get<SpecialWeapon>(listSpecicalWeaponData[index - 1].nameWeapon);
        spItem.ActiveSpWeapon(activePos);
    }
    public void Cooldown(float cooldownTime)
    {
        StartCoroutine(CooldownSpWeapons(cooldownTime));
    }
    private IEnumerator CooldownSpWeapons(float cooldown)
    {
        float currentCooldown = cooldown;
        while (currentCooldown > 0)
        {
            foreach (var icon in listIcon) icon.CooldownSpWeapon(currentCooldown / cooldown);
            float frameTime = Time.fixedDeltaTime;
            yield return new WaitForSeconds(frameTime);
            currentCooldown -= frameTime;
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
                foreach (var icon in listIcon) icon.CooldownSpWeapon(currentCooldown / cooldown);
            }
        }

        yield return null;
    }

}
