using UnityEngine;
public class RunSlime : Enemy
{
    public float heightJump;
    private float yVelocity;
    private float xVelocity;
    private bool isAttack;
    private float gravity = -9.81f * 2;
    private float xContact;
    public void IntinialEnemy()
    {
        EnemyStatus status = EnemySpawner.Instance.GetEnemyStatus(nameObject);
        IntinializeEnemy(status);
        direction = Vector2.left;
        multiplyMove = 1;
        isAttack = false;
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
            if (!isAttack)
            {
                anim.Play("JumpAttack");
                xContact = (hit.transform.position.x + (-direction.x) * hit.collider.GetComponent<BoxCollider2D>().bounds.size.x / 2);
                float jumpTime = Mathf.Sqrt(-2 * heightJump / gravity);
                xVelocity = (transform.position.x - xContact) / jumpTime;
                yVelocity = -gravity * jumpTime;
            }
            else
            {
                if (transform.position.x - xContact <= .1f)
                {
                    anim.Play("Explosion");
                    //AudioManager.Instance.PlaySFX("BoomExplosion");
                    return;
                } 
                yVelocity += gravity * Time.deltaTime;
                transform.position += xVelocity * Vector3.left * multiplyMove * Time.deltaTime;
                transform.position += yVelocity * Vector3.up * multiplyMove * Time.deltaTime;
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
        isAttack = true;
    }
    public void Explosion()
    {
        PlayAudio();
        var hit = Physics2D.Raycast(transform.position, Vector2.left, status.distanceAttack, playerLayer);
        if (hit.collider == null) return;
        PlayerHealth health = hit.transform.GetComponent<PlayerHealth>();
        health.TakeHit(status.damage, false); 
    }
    public void ExplosionEvent()
    {
        multiplyMove = 0f;
        sliderCanvasGroup.gameObject.SetActive(false);
        enemyCollider.enabled = false;
        controller.RemoveEnemy(this);
        if (currentEffect == SpEffect.Burn) controller.RemoveBurnEnemy(this);
        StopFreeze();
        Disactive();
    }
    public override void OnCreate()
    {
        IntinialEnemy();
    }
}
