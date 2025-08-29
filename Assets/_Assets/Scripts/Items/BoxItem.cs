using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : BaseItem
{
    private string item;
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
        GameManager.Instance.ActiveBoxEffect(transform.position);
        CoinPool coin = PoolManager.Instance.Get<CoinPool>("Coin");
        coin.ActiveCoin(transform.position);
        gameObject.SetActive(false);
    }
    public override void InteractionItem()
    {
        base.InteractionItem();
        anim.Play("Collect");
    }
}
