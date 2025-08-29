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
        for (int i = 0; i < listIcon.Count; i++)
        {
            listIcon[i].SetIcon(listSpecicalWeaponData[i].icon, listSpecicalWeaponData[i].currentOwner);
        }
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
        if (index == 1)
        {
            SpecialWeapon boom = PoolManager.Instance.Get<SpecialWeapon>("Boom");
            boom.ActiveSpWeapon(activePos);
        } 
        if (index == 2)
        {
            SpecialWeapon firePotion = PoolManager.Instance.Get<SpecialWeapon>("IcePotion");
            firePotion.ActiveSpWeapon(activePos);
        } 
        //if (index == 3) snow.ActiveSpWeapon(activePos);
        if (index == 3)
        {
            SpecialWeapon stopSign = PoolManager.Instance.Get<SpecialWeapon>("StopSign");
            stopSign.ActiveSpWeapon(activePos);
        }
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
