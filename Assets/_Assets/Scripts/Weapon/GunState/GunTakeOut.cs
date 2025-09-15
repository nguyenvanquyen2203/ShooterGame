using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTakeOut : BaseState<GunMachine>
{
    public GunTakeOut(GunMachine machine) : base(machine)
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void OnEnter()
    {
        machine.ChangeAnim(PlayerAnimationState.PlayerTakeOutAnim);
        machine.SetUIGun();
    }

    public override void OnExit()
    {
        
    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {

    }

    public override void Update()
    {

    }
}
