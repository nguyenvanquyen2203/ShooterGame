using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : WeaponCollectItem
{
    private static WeaponManager instance;
    public static WeaponManager Instance { get { return instance; } }
    [Header("Gun")]
    public List<GunInformation> gunInfos;
    public List<GunGameIcon> listGunIcon;
    private int currentIndexGun = 0;

    [Header("Special Weapon")]
    public SpecialManager specialManager;
    public SpecialWeaponShow specialWeapon;
    public float specialWeaponDelay;
    private float specialWeaponCooldown;
    private int currentIndexWeapon = 0;

    private List<(int, int)> bulletPerAmmo;

    private GunMachine gunCtrl;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        gunCtrl = GetComponent<GunMachine>();
    }
    void Start()
    {
        gunInfos = InGameData.Instance.gunEquips;
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
        for (int i = gunInfos.Count; i < listGunIcon.Count; i++)
        {
            listGunIcon[i].gameObject.SetActive(false);
        }
        gunCtrl.SetGun(gunInfos[0], bulletPerAmmo[0].Item1, bulletPerAmmo[0].Item2);
    }
    private void Update()
    {
        #region Set Gun
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCurrentGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCurrentGun(1);
        }
        #endregion
        #region Set special weapon
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetSpecialWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetSpecialWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetSpecialWeapon(3);
        }
        #endregion
        if (specialWeaponCooldown > 0) specialWeaponCooldown -= Time.deltaTime;
    }
    private void SetCurrentGun(int newIndex)
    {
        if (newIndex > listGunIcon.Count - 1) return;
        if (currentIndexWeapon != 0) CancelSpecialWeapon();
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
    private void SetSpecialWeapon(int index)
    {
        if (index > InGameData.Instance.specialItemEquips.Count) return;
        if (specialWeaponCooldown > 0) return;
        SpecialWeaponData spWeapon = InGameData.Instance.GetSpWeapon(index - 1);
        if (spWeapon.currentOwner <= 0) return;
        if (index == currentIndexWeapon)
        {
            CancelSpecialWeapon();
            return;
        }
        currentIndexWeapon = index;
        specialWeapon.ActiveSpecialWeapon(spWeapon.icon);
        specialManager.ActiveSpWeapon(currentIndexWeapon);
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
    private void CancelSpecialWeapon()
    {
        currentIndexWeapon = 0;
        specialWeapon.gameObject.SetActive(false);
        specialManager.DisaciveSpWeapon();
    }
    public void ClickAction()
    {
        if (currentIndexWeapon == 0) gunCtrl.ClickAction();
    }
    public void StopClickAction()
    {
        if (currentIndexWeapon != 0)
        {
            specialManager.Cooldown(specialWeaponDelay);
            specialWeaponCooldown = specialWeaponDelay;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            specialManager.UseSpWeapon(currentIndexWeapon, mousePos);
            CancelSpecialWeapon();
        } 
        else gunCtrl.StopClickAction();
    }
    public (GunInformation, Vector3) GetGunRandom()
    {
        int randomIndex = Random.Range(0, gunInfos.Count);
        return (gunInfos[randomIndex], Camera.main.ScreenToWorldPoint(listGunIcon[randomIndex].transform.position));
    }
    public override void WeaponCollect(string nameWeapon)
    {
        Debug.Log("Collect special weapon with name " + nameWeapon);
        for (int i = 0; i < gunInfos.Count; i++)
        {
            var gun = gunInfos[i];
            if (gun.nameGun == nameWeapon)
            {
                (int a, int b) = bulletPerAmmo[i];
                b += gun.magazineSize;
                bulletPerAmmo[i] = (a, b);
                //listGunIcon[i].ReloadSpWeaponIcon(listSpecicalWeaponData[i].currentOwner);
                listGunIcon[i].SetIcon(gunInfos[i].image, b);
                return;
            }
        }
    }
    public void SaveGunBullet()
    {
        for (int i = 0; i < gunInfos.Count; i++)
        {
            (int bullet, int ammo) = bulletPerAmmo[i];
            gunInfos[i].reserveAmmo = bullet + ammo;
        }
    }
}
