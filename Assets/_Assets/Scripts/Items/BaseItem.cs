using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    protected Animator anim;
    protected BoxCollider2D itemCollider;
    public void ActiveItem(Vector3 activePos)
    {
        itemCollider.enabled = true;
        transform.position = activePos;
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
