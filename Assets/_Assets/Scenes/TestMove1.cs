using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove1 : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 dir;
    float moveSpeed;
    Vector3 targetPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Active(Vector3 _dir, float _speed, Vector3 _target)
    {
        dir = _target.normalized;
        moveSpeed = _speed;
        targetPos = _target;
        gameObject.SetActive(true);
        rb.velocity = dir * moveSpeed;
        Invoke(nameof(DisableGO), targetPos.magnitude / moveSpeed);
    }
    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }
    public void DisableGO()
    {
        gameObject.SetActive(false);
    }
}
