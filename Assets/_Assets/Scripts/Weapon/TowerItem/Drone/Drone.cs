using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Animator anim;
    private float attackDelay = 2f;
    private float cooldownTime;
    private List<Enemy> flyEnemies;
    public LayerMask enemyLayer;
    public NormalBullet bullet;
    public float damage;
    public float speed;
    private Enemy targetEnemy;
    // Start is called before the first frame update
    private void Awake()
    {
        OptionDefenderData drone = InGameData.Instance.GetTowerBuff("Drone");
        if (drone.currentLv <= 0) gameObject.SetActive(false);
        else damage = drone.value;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        bullet.SetBullet(speed, damage, enemyLayer);
        flyEnemies = new();
        anim.Play("Idle");
    }
    private void FixedUpdate()
    {
        if (cooldownTime > 0f) cooldownTime -= Time.fixedDeltaTime;
        else
        {
            var hit = Physics2D.BoxCast(transform.position, new Vector2(1f, 5f), 0f, Vector2.right, 10f, enemyLayer);
            if (hit.collider != null)
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();    
                Attack(enemy);
            }
        }
    }
    public void Attack(Enemy enemy)
    {
        cooldownTime = attackDelay;
        targetEnemy = enemy;
        anim.Play("Attack");
    }
    public void AttackEvent()
    {
        bullet.ActiveBullet(transform.position + Vector3.right * .5f, targetEnemy.transform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FlyingEnemy")) flyEnemies.Add(collision.gameObject.GetComponent<Enemy>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FlyingEnemy")) flyEnemies.Remove(collision.gameObject.GetComponent<Enemy>());
    }
}
