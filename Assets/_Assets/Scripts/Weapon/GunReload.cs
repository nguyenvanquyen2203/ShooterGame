using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReload : BaseState<GunMachine>
{
    public GunReload(GunMachine machine) : base(machine)
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void OnEnter()
    {
        machine.ChangeAnim(PlayerAnimationState.PlayerReloadAnim);
    }

    public override void OnExit()
    {

    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        WeaponManager.Instance.Reload();
    }

    public override void Update()
    {

    }
}
