using UnityEngine;
using DG.Tweening;
public abstract class ItemBox : BaseItem
{
    protected BoxItemPool boxItem;
    protected Vector3 targetMove;
    protected Vector3 originalPosition;
    protected float gravity;
    public float multiplyG = 2;
    public float h = 3f;
    protected float startV;
    protected float currentV;
    protected float xMove;
    protected bool isCollect;
    private void Awake()
    {
        IntinializeItem();
        boxItem = GetComponent<BoxItemPool>();
    }
    //public abstract void CollectMove();
    public virtual void CollectMove()
    {
        transform.DOMove(targetMove, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            CollectAction();
            //boxItem.OwnerPool.ReturnToPool(boxItem);
        });
    }
    public override void InteractionItem()
    {
        AudioManager.Instance.PlaySFX("CollectCoin");
        isCollect = true;
        base.InteractionItem();
        CollectEvent();
    }
    public abstract void CollectAction();
    public void SetTargetMove(Vector3 targetMove)
    {
        this.targetMove = targetMove;
    }
    public abstract void LandingEvent();
    private void Update()
    {
        if (isCollect) return;
        if (startV < .5f)
        {
            LandingEvent();
            return;
        }
        currentV += gravity * Time.deltaTime;
        transform.position += (Vector3.up * currentV + Vector3.right * xMove) * Time.deltaTime;
        if (transform.position.y <= originalPosition.y)
        {
            startV /= 2;
            currentV = startV;
            transform.position = new Vector3(transform.position.x, originalPosition.y, transform.position.z);
        }
    }
}
