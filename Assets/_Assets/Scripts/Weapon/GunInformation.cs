using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Gun", fileName = "Gun")]
public class GunInformation : ScriptableObject
{
    [Header("Gun Information")]
    public string nameGun;
    public Sprite image;
    public Vector3 headPos;
    public float fireDelayTime;
    public float damage;
    public int magazineSize;
    public int reserveAmmo;
    public float reloadTime;
    public Vector2 recoilAround;
    public AnimatorOverrideController gunAnimator;
    public bool isRightHold;
    public Vector3 localPosition;
    public Vector3 localRotation;

    [Header("Bullet prefabs")]
    public PoolObj<BulletController> bullet;
    public PoolObj<BulletExplosion> explosion;

    public string GetNameBullet() => bullet.poolName;
    public string GetNameExplosion() => explosion.poolName;
    public void SetGunInfo(string nameGun, Sprite image, float damage, int reserveAmmo, int magazineSize)
    {
        this.nameGun = nameGun;
        this.image = image;
        this.damage = damage;
        this.reserveAmmo = reserveAmmo;
        this.magazineSize = magazineSize;
    }
}
