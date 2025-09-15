using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdle : BaseState<GunMachine>
{
    private float idleTime;
    public GunIdle(GunMachine machine) : base(machine)
    {
    }

    public override void FixedUpdate()
    {
        
    }

    public override void OnEnter()
    {
        idleTime = 1.5f;
        machine.ChangeAnim(PlayerAnimationState.PlayerIdleAnim);
    }

    public override void OnExit()
    {
        
    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        
    }

    public override void Update()
    {
        if (idleTime > 0f) idleTime -= Time.deltaTime;
        else if (machine.CanReload()) machine.ChangeState(machine.GunReload);
    }
}
