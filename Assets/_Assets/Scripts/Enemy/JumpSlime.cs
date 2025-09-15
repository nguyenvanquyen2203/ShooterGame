using UnityEngine;
public class JumpSlime : Enemy
{
    public float heightJump;
    private float yVelocity;
    private float xVelocity;
    private float gravity = -9.81f * 2;
    private float xContact;
    private float yGround;
    private bool isJump;
    public void IntinialEnemy()
    {
        EnemyStatus status = EnemySpawner.Instance.GetEnemyStatus(nameObject);
        IntinializeEnemy(status);
        direction = Vector2.left;
        multiplyMove = 1;
        isJump = false;
    }
    private void FixedUpdate()
    {
        if (cooldownAttack > 0) cooldownAttack -= Time.fixedDeltaTime;
        if (burnCooldown > 0) burnCooldown -= Time.fixedDeltaTime;
    }
    public override void ActiveEnemy(Vector3 position, WaveController controller)
    {
        base.ActiveEnemy(position, controller);
        yGround = transform.position.y;
    }
    public override void Action()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.left, status.distanceAttack, playerLayer);
        if (hit.collider != null)
        {
            anim.Play("Explosion");
            /*if (!isAttack)
            {
                xContact = (hit.transform.position.x + (-direction.x) * hit.collider.GetComponent<BoxCollider2D>().bounds.size.x / 2);
                float jumpTime = Mathf.Sqrt(-2 * heightJump / gravity);
                xVelocity = (transform.position.x - xContact) / jumpTime;
                yVelocity = -gravity * jumpTime;
                isAttack = true;
            }
            else
            {
                if (transform.position.x - xContact <= .1f)
                {
                    anim.Play("Explosion");
                    return;
                }
                yVelocity += gravity * Time.deltaTime;
                transform.position += xVelocity * Vector3.left * multiplyMove * Time.deltaTime;
                transform.position += yVelocity * Vector3.up * multiplyMove * Time.deltaTime;
            }*/
        }
        else
        {
            if (isJump)
            {
                Vector3 dir = new Vector3(direction.x, direction.y, 0f);
                if (currentEffect == SpEffect.Cool)
                {
                    transform.position += status.moveSpeed * dir * multiplyMove * Time.deltaTime * .5f;
                }
                else transform.position += status.moveSpeed * dir * multiplyMove * Time.deltaTime;
                yVelocity += gravity * Time.deltaTime;
                transform.position += yVelocity * Vector3.up * Time.deltaTime;
                if (Mathf.Abs(yVelocity) <= .2f) anim.Play("JumpToFall");
                if (transform.position.y <= yGround) 
                {
                    isJump = false;
                    anim.Play("Land");
                }
            }
        }
    }
    public override void AttackEvent()
    {
        
    }
    public void Jump()
    {
        yVelocity = -gravity * Mathf.Sqrt(-2 * heightJump / gravity);
        isJump = true;
    } 
    public void Explosion()
    {
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
