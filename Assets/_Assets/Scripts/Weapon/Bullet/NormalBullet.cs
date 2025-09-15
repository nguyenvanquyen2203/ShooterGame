using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    private Animator anim;
    private Vector3 target;
    private Vector3 direction;
    private float damage;
    private float bulletSpeed;
    private LayerMask targetLayer;
    private string currentAnim;
    private float normalDir;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void SetBullet(float speed, float damage, LayerMask targetLayer)
    {
        bulletSpeed = speed;
        this.damage = damage;
        this.targetLayer = targetLayer;
    }
    public void ActiveBullet(Vector3 startPos, Transform target)
    {
        //Calculator direction vector
        currentAnim = "Idle";
        if (startPos.x < target.position.x) normalDir = 1;
        else normalDir = -1;
        Vector3 moveVector = target.transform.position - startPos;
        direction = moveVector.normalized;
        // Rotate bullet by dir
        Vector3 targetEulerAngles = Vector3.zero;
        targetEulerAngles.z = Mathf.Clamp(Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg, -360f, 360f);
        transform.eulerAngles = targetEulerAngles;
        //Intinialize bullet
        transform.position = startPos;
        this.target = target.transform.position - (target.GetComponent<BoxCollider2D>().bounds.size.x / 2 * normalDir) * Vector3.right;
        //transform.localScale = new Vector3(0f, 0f, 1f);
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if ((transform.position.x - target.x) * normalDir >= -.1f) ExplosionBullet();
        else transform.position += direction * bulletSpeed * Time.deltaTime;
    }
    public void ExplosionBullet()
    {
        if (currentAnim == "Idle")
        {
            var hit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, Vector2.zero, 0f, targetLayer);
            if (hit.collider != null)
                hit.transform.GetComponent<IHealth>().TakeHit(damage, false);
        }
        currentAnim = "Explosion";
        anim.Play(currentAnim);
    }
    public void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
