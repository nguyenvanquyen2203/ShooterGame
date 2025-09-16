using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : BaseItem
{
    public WeaponBoxItem gunIcon;
    public WeaponBoxItem spWeaponIcon;
    public SpecialManager spWeaponManager;
    public WeaponManager gunManager;
    private void Awake()
    {
        IntinializeItem();
    }
    public void Active(Vector3 activePos)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
        itemCollider.enabled = true;
    }
    public override void CollectEvent()
    {
        AudioManager.Instance.PlaySFX("BoxBreak");
        GameManager.Instance.ActiveBoxEffect(transform.position);
        int randomNumber = Random.Range(0, 100);
        if (randomNumber < 60)
        {
            GameManager.Instance.GetCoinIconPos();
            CoinPool coin = PoolManager.Instance.Get<CoinPool>("Coin");
            coin.ActiveItem(transform.position);
            coin.GetComponent<CoinItem>().SetTargetMove(GameManager.Instance.GetCoinIconPos());
        }
        else
        {
            if (randomNumber < 80)
            {
                // Spawn gun bullet item
                (GunInformation gun, Vector3 iconPos) = WeaponManager.Instance.GetGunRandom();
                gunIcon.SetWeaponItem(gun.image, gun.nameGun);
                gunIcon.SetTargetMove(iconPos);
                gunIcon.ActiveItem(transform.position);
            }
            else
            {
                // SP weapon Item
                (SpecialWeaponData weapon, Vector3 iconPos) = spWeaponManager.GetSpWeaponRandom();
                spWeaponIcon.SetWeaponItem(weapon.icon, weapon.nameWeapon);
                spWeaponIcon.ActiveItem(transform.position);
                spWeaponIcon.SetTargetMove(iconPos);
            }
        }
        gameObject.SetActive(false);
    }
    public override void InteractionItem()
    {
        base.InteractionItem();
        anim.Play("Collect");
        
    }
}
