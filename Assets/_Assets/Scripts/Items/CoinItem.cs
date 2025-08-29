using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinItem : BaseItem
{
    private CoinPool coin;
    private void Awake()
    {
        IntinializeItem();
        coin = GetComponent<CoinPool>();
    }
    public override void CollectEvent()
    {
        SingleEffect effect = PoolManager.Instance.Get<SingleEffect>("CoinCollect");
        effect.ActiveEffect(transform.position);
        CollectMove();
    }
    public void CollectMove()
    {
        transform.DOMove(GameManager.Instance.GetCoinIconPos(), 2f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            coin.OwnerPool.ReturnToPool(coin);
            //gameObject.SetActive(false);
        });
    }
    public override void InteractionItem()
    {
        base.InteractionItem();
        CollectEvent();
    }
}
