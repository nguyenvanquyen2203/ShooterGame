using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class GunMachine : StateMachine
{
    private static GunMachine instance;
    public static GunMachine Instance { get { return instance; } }

    public Transform headGun;
    private Vector3 headGunPos;
    public SpriteRenderer gunSprite;
    public LayerMask enemyLayer;

    public TextMeshProUGUI bulletTxt;

    public Transform muzzleFlash;
    private float fireDelayCooldown;
    private bool canAttack;
    private GunInformation currentGun;

    private int numberBullet;
    private int magazineSize;
    private int reverseAmmo;

    private BaseState<GunMachine> currenState;
    private GunIdle idleState;
    private GunAttack attackState;
    private GunReload reloadState;
    private GunPutAway putAwayState;
    private GunTakeOut takeOutState;
    private GunThrowWeapon throwState;
    private bool isLockState;

    public GunIdle IdleState { get { return idleState; } }
    public GunAttack GunAttack { get { return attackState; } }
    public GunReload GunReload { get { return reloadState; } }
    public GunTakeOut TakeOutState { get { return takeOutState; } }
    public GunPutAway PutAwayState { get { return putAwayState; } }
    public GunThrowWeapon ThrowState { get { return throwState; } }
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        instance = this;
        idleState = new GunIdle(this);
        attackState = new GunAttack(this);
        reloadState = new GunReload(this);
        putAwayState = new GunPutAway(this);
        takeOutState = new GunTakeOut(this);
        throwState = new GunThrowWeapon(this);
    }
    void Start()
    {
        isLockState = false;
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (fireDelayCooldown > 0f) fireDelayCooldown -= Time.deltaTime;
        else
        {
            canAttack = true;
        }
        currenState.Update();
    }
    public void ClickAction()
    {
        if (!canAttack || numberBullet <= 0) return;
        ChangeState(attackState);
    }
    public bool CanAttack() => canAttack;
    public void LockState() => isLockState = true;
    public void UnlockState() => isLockState = false;
    public void StopClickAction()
    {
        
    }
    public void ResetFireCooldown() => fireDelayCooldown = currentGun.fireDelayTime;
    public void ChangeState(BaseState<GunMachine> newState)
    {
        if (isLockState) return;
        if (currenState == newState) return;
        if (currenState != null) currenState.OnExit();
        currenState = newState;
        currenState.OnEnter();
    } 
    public void ToIdleState()
    {
        ChangeState(IdleState);
    }
    public void Shoot()
    {
        if (numberBullet <= 0) return;
        AudioManager.Instance.PlaySFX($"{currentGun.nameGun + "Shoot"}");
        numberBullet--;
        ShowBullet();
        canAttack = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;
        anim.Play(PlayerAnimationState.PlayerAttackAnim);
        BulletController pool = PoolManager.Instance.Get<BulletController>(currentGun.GetNameBullet());

        // Apply accuracy of gun to calculator target position
        Vector2 recoilSquare = currentGun.recoilAround;
        float randomX = Random.Range(-recoilSquare.x, recoilSquare.x);
        float randomY = Random.Range(-recoilSquare.y, recoilSquare.y);
        Vector3 targetPos = mousePos + (new Vector3(randomX, randomY, 0f)) * (headGunPos - mousePos).sqrMagnitude / 100f;
        pool.ActiveBullet(headGunPos, targetPos, currentGun.damage);
    }
    public void SetGun(GunInformation newGun, int bullet, int _reverseAmmo)
    {
        currentGun = newGun;
        SetGun(bullet, _reverseAmmo);
        magazineSize = currentGun.magazineSize;
        anim.runtimeAnimatorController = currentGun.gunAnimator;
        if (headGunPos != Vector3.zero) ChangeState(putAwayState);
        //gunSprite.sprite = currentGun.image;
        headGunPos = gunSprite.transform.position + gunSprite.transform.right * currentGun.headPos.x + gunSprite.transform.up * currentGun.headPos.y;
        muzzleFlash.localPosition = currentGun.headPos;
    }
    public void SetGun(int bullet, int _reverseAmmo)
    {
        numberBullet = bullet;
        reverseAmmo = _reverseAmmo;
        ShowBullet();
    }
    public void SetUIGun()
    {
        gunSprite.sprite = currentGun.image;
        gunSprite.transform.localPosition = currentGun.localPosition;
    }
    private void ShowBullet()
    {
        bulletTxt.text = $"{numberBullet}/{reverseAmmo}";
    }
    public int GetBullet() => numberBullet;
    public bool CanReload()
    { 
        if (numberBullet < magazineSize && reverseAmmo > 0) return true;
        else return false;
    }
    public void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        currenState.OnTriggerEvent(type);
    }
}