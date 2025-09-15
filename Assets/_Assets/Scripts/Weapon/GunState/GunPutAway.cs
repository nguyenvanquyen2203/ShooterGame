using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPutAway : BaseState<GunMachine>
{
    public GunPutAway(GunMachine machine) : base(machine)
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void OnEnter()
    {
        machine.ChangeAnim(PlayerAnimationState.PlayerPutAwayAnim);
        machine.LockState();
    }

    public override void OnExit()
    {

    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        machine.UnlockState();
        machine.ChangeState(machine.TakeOutState);
    }

    public override void Update()
    {

    }
}
