using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponBoxItem : ItemBox
{
    public SpriteRenderer sprite;
    public WeaponCollectItem weaponCollect;
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
    private void OnEnable()
    {
        gravity = -9.8f * multiplyG;
        isCollect = false;
        startV = Mathf.Sqrt(-2f * h * gravity);
        currentV = startV;
        xMove = Random.Range(-1f, 1f);
        originalPosition = transform.position;
    }
    public override void CollectAction()
    {
        //Debug.Log("CollectWeapon");
    }

    public override void LandingEvent()
    {
        //CollectMove();
        isCollect = true;
        return;
    }

    public override void CollectMove()
    {
        transform.DOMove(targetMove, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            weaponCollect.WeaponCollect(nameWeapon);
            gameObject.SetActive(false);
        });
    }
}
