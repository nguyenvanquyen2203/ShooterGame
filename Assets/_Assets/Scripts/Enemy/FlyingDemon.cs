using UnityEngine;

public class FlyingDemon : Enemy
{
    public NormalBullet bullet;
    public float bulletSpeed = 20f;
    public Transform tower;
    public override void Action()
    {
        if (transform.position.x - tower.position.x < status.distanceAttack)
        {
            if (cooldownAttack <= 0)
            {
                cooldownAttack = status.delayAttack;
                anim.Play("Attack");
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
    private void FixedUpdate()
    {
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
        if (burnCooldown > 0) burnCooldown -= Time.fixedDeltaTime;
    }
    public override void ActiveEnemy(Vector3 position, WaveController controller)
    {
        base.ActiveEnemy(position, controller);
        tower = PlayerTower.Instance.transform;
    }
    public override void AttackEvent()
    {
        bullet.ActiveBullet(transform.position + Vector3.right * -.75f + Vector3.up * -.3f, tower);
    }
    public void IntinialEnemy()
    {
        EnemyStatus status = EnemySpawner.Instance.GetEnemyStatus(nameObject);
        IntinializeEnemy(status);
        direction = Vector2.left;
        multiplyMove = 1;
    }
    public override void OnCreate()
    {
        IntinialEnemy();
        bullet.SetBullet(bulletSpeed, status.damage, playerLayer);
    }    
}
