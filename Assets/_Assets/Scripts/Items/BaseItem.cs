using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    protected Animator anim;
    protected BoxCollider2D itemCollider;
    public virtual void ActiveItem(Vector3 activePos)
    {
        itemCollider = GetComponent<BoxCollider2D>();
        itemCollider.enabled = true;
        transform.position = activePos;
        gameObject.SetActive(true);
    }
    public void IntinializeItem()
    {
        anim = GetComponent<Animator>();
        itemCollider = GetComponent<BoxCollider2D>();
    }
    public virtual void InteractionItem()
    {
        if (anim == null) anim = GetComponent<Animator>();
        itemCollider.enabled = false;
    }
    public abstract void CollectEvent(); 
}
