using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour, MovementObserver
{
    public Vector3 Direction { get { return dir; } }
    public float MoveSpeed { get { return moveSpeed; } }

    public Vector3 TargetPos => targetPos;
    public Vector3 targetPos;

    public Vector3 dir;
    public float moveSpeed;
    public bool Move()
    {
        transform.position += moveSpeed * dir * Time.deltaTime;
        if ((transform.position - TargetPos).sqrMagnitude <= .01f) return false;
        return true;
    }

    private void OnEnable()
    {
        transform.position = Vector3.zero;
        MovementManager.Instance.Register(this);
    }
    public void DisableGO()
    {
        gameObject.SetActive(false);
    }
    public void Active(Vector3 _dir, float _speed, Vector3 _target)
    {
        dir = _target.normalized;
        moveSpeed = _speed;
        targetPos = _target;
        gameObject.SetActive(true);
    }

    public void DoneMove()
    {
        DisableGO();
    }
}
