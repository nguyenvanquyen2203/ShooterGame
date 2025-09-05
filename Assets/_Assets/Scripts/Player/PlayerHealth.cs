using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerHealth : MonoBehaviour,IHealth
{
    public float maxHP;
    protected float currentHp;
    public Slider hpSlider;
    private void OnEnable()
    {
        currentHp = maxHP;
    }
    public abstract void Destroy();

    public virtual void TakeHit(float damage, bool isCritical)
    {
        currentHp -= damage;
        hpSlider.value = currentHp / maxHP;
        if (currentHp <= 0)
        {
            Destroy();
            return;
        }
    }
}
