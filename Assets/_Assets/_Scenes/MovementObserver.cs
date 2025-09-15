using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementObserver
{
    Vector3 Direction { get; }
    float MoveSpeed { get; }
    Vector3 TargetPos { get; }
    bool Move();
    void DoneMove();
}
