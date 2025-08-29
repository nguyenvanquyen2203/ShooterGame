using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerHealth : MonoBehaviour
{
    public float maxHP;
    private float currentHp;
    public Slider hpSlider;
    private void OnEnable()
    {
        currentHp = maxHP;
    }
    public virtual void TakeDame(float damage)
    {
        currentHp -= damage;
        hpSlider.value = currentHp / maxHP;
        if (currentHp <= 0)
        {
            Destroy();
            return;
        } 
    }
    public abstract void Destroy();
}
