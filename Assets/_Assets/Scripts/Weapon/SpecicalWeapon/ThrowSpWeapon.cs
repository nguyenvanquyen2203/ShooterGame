using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpWeapon : SpecialWeapon
{
    public string nameExplosion;
    public float xVelocity = 20f;
    public float damage;
    private float yVelocity;
    private Vector3 moveVector;
    private float gravity = -9.81f * 3;
    private float timeMove;
    private void OnEnable()
    {
        timeMove = (targetPos.x + 11f) / xVelocity;
        yVelocity = (targetPos.y - gravity * timeMove * timeMove / 2) / timeMove;
        transform.position = Vector3.right * -11f;
        moveVector = Vector3.up * yVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = xVelocity;
        moveVector.y += gravity * Time.deltaTime;

        transform.position += moveVector * Time.deltaTime;
        if ((transform.position - targetPos).sqrMagnitude <= .04f) ActiveEffect();
    }
    public void ActiveEffect()
    {
        SpExplosion effect = PoolManager.Instance.Get<SpExplosion>(nameExplosion);
        effect.ActiveExplosion(transform.position, damage);
        OwnerPool.ReturnToPool(this);
    }

    public override void OnCreate()
    {
        
    }
}
