using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunController : MonoBehaviour
{
    private static GunController instance;
    public static GunController Instance { get { return instance; } }
    private Animator anim;
    public SpriteRenderer gunSprite;

    public TextMeshProUGUI nameGunTxt;
    public TextMeshProUGUI bulletTxt;

    private GunInformation currentGun;
    public Transform headGun;
    public Transform muzzleFlash;
    private bool canShot;
    private float delayTime;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        canShot = true;
        delayTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!canShot)
        {
            if (delayTime > 0f) delayTime -= Time.fixedDeltaTime;
            else canShot = true;
        }
    }
    public void Shoot(Vector3 mousePos)
    {
        if (!canShot) return;
        canShot = false;
        delayTime = currentGun.fireDelayTime;
        anim.Play("GunAttack");
        BulletController pool = PoolManager.Instance.Get<BulletController>(currentGun.GetNameBullet());

        // Apply accuracy of gun to calculator target position
        /*float randomX = currentGun.recoilRange * Random.Range(currentGun.accuracy - 1, 1 - currentGun.accuracy);
        float randomY = currentGun.recoilRange * Random.Range(currentGun.accuracy - 1, 1 - currentGun.accuracy);
        Vector3 targetPos = mousePos + (new Vector3(randomX, randomY, 0f)) * (headGun.position - mousePos).magnitude / 5f;
        pool.ActiveBullet(headGun.position, targetPos);*/
    }
    public void SetGun(GunInformation newGun)
    {
        currentGun = newGun;
        anim.runtimeAnimatorController = currentGun.gunAnimator;
        gunSprite.sprite = currentGun.image;
        headGun.localPosition = currentGun.headPos;
        muzzleFlash.localPosition = currentGun.headPos + new Vector3(-.1f, -.075f, 0f);
    }
}
