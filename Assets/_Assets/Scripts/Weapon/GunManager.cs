using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    private static GunManager instance;
    public static GunManager Instance { get { return instance; } }
    public List<GunInformation> gunInfos;
    public List<GunGameIcon> listGunIcon;
    private List<(int, int)> bulletPerAmmo;

    private GunMachine gunCtrl;
    private int currentIndexGun = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        gunCtrl = GetComponent<GunMachine>();
    }
    void Start()
    {
        //Spawn pool need for game
        foreach (var gun in gunInfos)
        {
            PoolManager.Instance.CreatePool(gun.bullet);
            PoolManager.Instance.CreatePool(gun.explosion);
        }

        //Config gun UI
        listGunIcon[0].ActiveGun();
        bulletPerAmmo = new();
        for (int i = 0; i < gunInfos.Count; i++)
        {
            int bulletInMagazine = Mathf.Min(gunInfos[i].magazineSize, gunInfos[i].reserveAmmo);
            int reserveAmmo = gunInfos[i].reserveAmmo - bulletInMagazine;
            bulletPerAmmo.Add((bulletInMagazine, reserveAmmo));
            listGunIcon[i].SetIcon(gunInfos[i].image, reserveAmmo);
        }
        gunCtrl.SetGun(gunInfos[0], bulletPerAmmo[0].Item1, bulletPerAmmo[0].Item2);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCurrentGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCurrentGun(1);
        }
    }
    private void SetCurrentGun(int newIndex)
    {
        if (newIndex == currentIndexGun) return;

        //Save bullet in magazine of gun in balo
        int numberBullet = gunCtrl.GetBullet();
        (int bulletInMagazine, int reserveAmmo) = bulletPerAmmo[currentIndexGun];
        bulletInMagazine = numberBullet;
        bulletPerAmmo[currentIndexGun] = (bulletInMagazine, reserveAmmo);

        gunCtrl.SetGun(gunInfos[newIndex], bulletPerAmmo[newIndex].Item1, bulletPerAmmo[newIndex].Item2);
        listGunIcon[currentIndexGun].DisactiveGun();
        listGunIcon[newIndex].ActiveGun();
        currentIndexGun = newIndex;
    }
    public void Reload()
    {
        int numberBullet = gunCtrl.GetBullet();
        (int bulletInMagazine, int reserveAmmo) = bulletPerAmmo[currentIndexGun];
        int numberBulletReload = Mathf.Min(gunInfos[currentIndexGun].magazineSize - numberBullet, reserveAmmo);
        bulletInMagazine = numberBullet + numberBulletReload;
        reserveAmmo -= numberBulletReload;
        bulletPerAmmo[currentIndexGun] = (bulletInMagazine, reserveAmmo);

        //Set Icon Ui
        listGunIcon[currentIndexGun].SetIcon(gunInfos[currentIndexGun].image, reserveAmmo);

        //Set Bullet/reserveAmmo UI
        gunCtrl.SetGun(bulletPerAmmo[currentIndexGun].Item1, bulletPerAmmo[currentIndexGun].Item2);
    }
}

[System.Serializable]
public class GunGameUI
{
    public GunInformation infor;
    public GunGameIcon iconObject;
}