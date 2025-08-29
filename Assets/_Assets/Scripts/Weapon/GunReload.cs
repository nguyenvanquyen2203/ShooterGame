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
        machine.ChangeAnim("GunReload");
    }

    public override void OnExit()
    {

    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        //GunManager.Instance.Reload();
        WeaponManager.Instance.Reload();
    }

    public override void Update()
    {

    }
}
