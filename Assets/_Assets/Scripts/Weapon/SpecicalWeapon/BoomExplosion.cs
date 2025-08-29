using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomExplosion : SpExplosion
{
    public override void ActiveExplosion(Vector3 activePos, float damage)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
        var hits = Physics2D.BoxCastAll(transform.position, boxSize, 0f, Vector2.zero, 0f, GunMachine.Instance.enemyLayer);
        foreach (var hit in hits)
        {
            bool critical = false;
            float multiplyDam = 1f;
            float sqrMagnitude = (activePos - hit.transform.position).sqrMagnitude;
            if (sqrMagnitude <= Mathf.Min(boxSize.x, boxSize.y)) 
            {
                if (Random.Range(0, 100) < 10f) critical = true;
            }
            else multiplyDam = 1 / sqrMagnitude;
            hit.collider.gameObject.GetComponent<Enemy>().TakeHit(damage * multiplyDam, critical);
        }
    }

    public override void OnCreate()
    {
        
    }
}
