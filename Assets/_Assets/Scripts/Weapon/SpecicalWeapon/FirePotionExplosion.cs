using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePotionExplosion : SpExplosion
{
    public override void ActiveExplosion(Vector3 activePos, float damage)
    {
        Vector3 activePosition = new Vector3(activePos.x, Mathf.Clamp(activePos.y, -2.5f, 2.5f), 0f);
        transform.position = activePosition;
        gameObject.SetActive(true);
        var hits = Physics2D.BoxCastAll(transform.position, boxSize, 0f, Vector2.zero, 0f, GunMachine.Instance.enemyLayer);
        foreach (var hit in hits)
        {
            hit.collider.gameObject.GetComponent<Enemy>().ActiveEffect(Enemy.SpEffect.Burn);
        }
    }

    public override void OnCreate()
    {
        
    }
}
