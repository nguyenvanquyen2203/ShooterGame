using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : PoolObject
{
    private Animator anim;
    public bool isGroupExplosion;
    public Vector2 boxSize;
    // Start is called before the first frame update
    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }
    public void ActiveExplosion(Vector3 activePos, float damage)
    {
        transform.position = activePos;
        gameObject.SetActive(true);
        anim.Play("BulletExplosion");
        if (isGroupExplosion)
        {
            var hits = Physics2D.BoxCastAll(transform.position, boxSize, 0f, Vector2.zero, 0f, GunMachine.Instance.enemyLayer);
            foreach (var hit in hits)
            {
                bool critical = false;
                float multiplyDam = 1f;
                float sqrMagnitude = (activePos - hit.transform.position).sqrMagnitude;
                if (sqrMagnitude <= 1)
                {
                    if (Random.Range(0, 100) < 10f) critical = true;
                }
                else multiplyDam = 1 / sqrMagnitude;
                hit.collider.gameObject.GetComponent<Enemy>().TakeHit(damage * multiplyDam, critical);
            }
        }
        else
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.zero, 0f, GunMachine.Instance.enemyLayer);
            if (hit.collider != null)
            {
                bool critical = false;
                float multiplyDam = 1f;
                float sqrMagnitude = (activePos - hit.transform.position).sqrMagnitude;
                if (sqrMagnitude <= 1)
                {
                    if (Random.Range(0, 100) < 10f) critical = true;
                }
                else multiplyDam = 1 / sqrMagnitude; 
                hit.collider.gameObject.GetComponent<Enemy>().TakeHit(damage * multiplyDam, critical);
            } 
        }
    }
    public void UnactiveExplosion()
    {
        OwnerPool.ReturnToPool(this);
    }

    public override void OnCreate()
    {
        anim = GetComponent<Animator>();
    }
}
