using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PoolObject
{
    public float bulletSpeed;
    public string nameExplosion;
    public Transform headBullet;
    private Vector3 direction;
    private Vector3 target;
    private IEnumerator shootCoroutine;
    private float damage;
    private void Awake()
    {
        /*shootCoroutine = ShootBullet();
        gameObject.SetActive(false);*/
    }
    public void SetNameExplosion(string name) => nameExplosion = name;
    public void ActiveBullet(Vector3 startPos, Vector3 target, float damage)
    {
        //Calculator direction vector
        Vector3 moveVector = target - startPos;
        direction = moveVector.normalized;
        // Rotate bullet by dir
        Vector3 targetEulerAngles = Vector3.zero;
        targetEulerAngles.z = Mathf.Clamp(Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg, -90f, 90f);
        transform.eulerAngles = targetEulerAngles;
        //Intinialize bullet
        transform.position = startPos;
        this.target = target;
        this.damage = damage;
        transform.localScale = new Vector3(0f, 0f, 1f);
        gameObject.SetActive(true);
        shootCoroutine = ShootBullet();
        StartCoroutine(shootCoroutine);
    }
    public void DisableBullet()
    {
        BulletExplosion explosion = PoolManager.Instance.Get<BulletExplosion>(nameExplosion);
        explosion.ActiveExplosion(headBullet.position, damage);
        StopCoroutine(shootCoroutine);
        OwnerPool.ReturnToPool(this);
    }
    private void Update()
    {
        transform.position += direction * bulletSpeed * Time.deltaTime;
        if ((headBullet.position.x - target.x ) >= -0.1f) DisableBullet();
    }
    IEnumerator ShootBullet()
    {
        Vector3 curScale = new Vector3(0f, 0f, 1f);
        Vector3 plusVector = new Vector3(1f, 1f, 0f);
        int numberLoop = 10;
        for (int i = 0; i < numberLoop; i++)
        {
            curScale += plusVector / numberLoop;
            transform.localScale = curScale;
            yield return new WaitForSeconds(.1f / numberLoop);
        }

        // Pause for a single frame
        yield return null;
    }

    public override void OnCreate()
    {
        shootCoroutine = ShootBullet();
        gameObject.SetActive(false);
    }
}
