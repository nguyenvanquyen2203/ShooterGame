using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletBoxItem : ItemBox
{
    private SpriteRenderer sprite;
    private string nameWeapon;
    public void SetWeaponItem(Sprite img, string _nameWeapon)
    {
        sprite.sprite = img;
        nameWeapon = _nameWeapon;
    }
    public override void CollectEvent()
    {
        CollectMove();
    }

    public override void CollectAction()
    {
        Debug.Log("Collect Gun Bullet");
    }

    public override void LandingEvent()
    {
        throw new System.NotImplementedException();
    }
}
