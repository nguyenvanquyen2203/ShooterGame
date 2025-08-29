using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttack : BaseState<GunMachine>
{
    public GunAttack(GunMachine machine) : base(machine)
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void OnEnter()
    {
        machine.ChangeAnim("GunAttack");
    }

    public override void OnExit()
    {

    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        
    }

    public override void Update()
    {
        if (machine.CanAttack())
        {
            machine.Shoot();
            machine.ResetFireCooldown();
        } 
        if (Input.GetMouseButtonUp(0) || machine.GetBullet() <= 0)
        {
            machine.ChangeState(machine.IdleState);
        }
    }
}
