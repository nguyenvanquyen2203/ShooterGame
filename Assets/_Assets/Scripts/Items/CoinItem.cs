using DG.Tweening;
using UnityEngine;

public class CoinItem : ItemBox
{
    protected ItemBox itemBox;
    public override void CollectAction()
    {
        GameManager.Instance.GetCoin(5);
        boxItem.OnReturnToPool();
        //gameObject.SetActive(false);
    }

    public override void CollectEvent()
    {
        SingleEffect effect = PoolManager.Instance.Get<SingleEffect>("CoinCollect");
        effect.ActiveEffect(transform.position);
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
    public override void ActiveItem(Vector3 activePos)
    {
        base.ActiveItem(activePos);
        gravity = -9.8f * multiplyG;
        isCollect = false;
        startV = Mathf.Sqrt(-2f * h * gravity);
        currentV = startV;
        xMove = Random.Range(-1f, 1f);
        originalPosition = activePos;
    }
    

    public override void LandingEvent()
    {
        CollectMove();
        isCollect = true;
        return;
    }
}
