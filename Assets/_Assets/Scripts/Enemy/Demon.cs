using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Demon : Enemy
{
    public void IntinialEnemy()
    {
        EnemyStatus status = EnemySpawner.Instance.GetEnemyStatus(nameObject);
        IntinializeEnemy(status);
        direction = Vector2.left;
        multiplyMove = 1;
    }
    private void FixedUpdate()
    {
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
        if (burnCooldown > 0) burnCooldown -= Time.fixedDeltaTime;
    }
    public override void Action()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.left, status.distanceAttack, playerLayer);
        if (hit.collider != null)
        {
            if (cooldownAttack <= 0)
            {
                cooldownAttack = status.delayAttack;
                anim.Play("Attack");
                PlayAudio();
                //AudioManager.Instance.PlaySFX("DemonAttack");
            }
        }
        else
        {
            anim.Play("Walk");
            Vector3 dir = new Vector3(direction.x, direction.y, 0f);
            if (currentEffect == SpEffect.Cool)
            {
                transform.position += status.moveSpeed * dir * multiplyMove * Time.deltaTime * .5f;
            } 
            else transform.position += status.moveSpeed * dir * multiplyMove * Time.deltaTime;
        }
    }

    public override void AttackEvent()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.left, status.distanceAttack, playerLayer);
        if (hit.collider == null) return;
        PlayerHealth health = hit.transform.GetComponent<PlayerHealth>();
        health.TakeHit(status.damage, false);
    }

    public override void OnCreate()
    {
        IntinialEnemy();
    }
}