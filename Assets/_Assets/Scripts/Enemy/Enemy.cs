using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Enemy : PoolObject
{
    public enum SpEffect
    {
        None,
        Burn,
        Cool
    }
    protected Animator anim;
    protected SpriteRenderer img;
    protected BoxCollider2D enemyCollider;
    public Slider slider;
    public CanvasGroup sliderCanvasGroup;
    public LayerMask playerLayer;
    protected EnemyStatus status;
    protected float multiplyMove;
    protected Vector2 direction;
    protected float currentHp;
    protected WaveController controller;
    protected float cooldownAttack;
    protected SpEffect currentEffect;
    protected float burnCooldown;
    protected Color targetColor = new Color(0.5f, 1f, 1f);
    protected bool isMaxColor;
    public virtual void IntinializeEnemy(EnemyStatus _status)
    {
        anim = GetComponent<Animator>();
        img = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<BoxCollider2D>();
        status = _status;
    }
    public void ActiveEnemy(Vector3 position, WaveController controller)
    {
        isMaxColor = true;
        currentEffect = SpEffect.None;
        this.controller = controller;
        multiplyMove = 1f;
        currentHp = status.maxHp;
        transform.position = position;
        gameObject.SetActive(true);
        enemyCollider.enabled = true;
        anim.Play("Walk");
        StopFreeze();
    }
    public void TakeHit(float damage, bool isCritical)
    {
        currentHp -= damage;
        if (isCritical)
        {
            Debug.Log("Critical");
            currentHp -= damage;
            TextEffect effect = PoolManager.Instance.Get<TextEffect>("CriticalTxt");
            effect.ActiveEffect(transform.position + Vector3.up * 2f, "CRITICAL!!!");
        }
        if (currentHp <= 0)
        {
            Death();
            return;
        } 
        DOTween.Kill(sliderCanvasGroup);
        sliderCanvasGroup.alpha = 1f;
        sliderCanvasGroup.gameObject.SetActive(true);
        slider.value = currentHp / status.maxHp;
        sliderCanvasGroup.DOFade(0f, 2f).SetEase(Ease.InQuart).OnComplete(() => {
            sliderCanvasGroup.gameObject.SetActive(false);
            DOTween.Kill(sliderCanvasGroup);
        });
    } 
    public void Death()
    {
        multiplyMove = 0f;
        DOTween.Kill(sliderCanvasGroup);
        sliderCanvasGroup.gameObject.SetActive(false);
        enemyCollider.enabled = false;
        anim.Play("Death");
        controller.RemoveEnemy(this);
        if (currentEffect == SpEffect.Burn) controller.RemoveBurnEnemy(this);
        StopFreeze();
    }
    public void Disactive()
    {
        OwnerPool.ReturnToPool(this);
    }
    public void ActiveEffect(SpEffect effect)
    {
        if (currentEffect != SpEffect.Burn)
        {
            currentEffect = effect;
            StopFreeze();
            controller.BurnEnemy(this);
        } 
    }
    public void SetMultiply(float newMultiply) => multiplyMove = newMultiply;
    public abstract void Action();
    public abstract void AttackEvent();
    public void Burn()
    {
        if (burnCooldown <= 0)
        {
            burnCooldown = 1f;
            TakeHit(1, false);
        } 
    }
    public void Freeze()
    {
        if (currentEffect == SpEffect.Burn) return;
        currentEffect = SpEffect.Cool;
        img.color = new Color(0f, 1f, 1f, 1f);
        anim.speed = .5f;
    }
    public void StopFreeze()
    {
        if (currentEffect == SpEffect.Burn) return;
        currentEffect = SpEffect.None;
        anim.speed = 1;
        img.color = new Color(1f, 1f, 1f, 1f);
    }
}
