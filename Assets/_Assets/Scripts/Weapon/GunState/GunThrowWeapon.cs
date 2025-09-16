using UnityEngine;
public class GunThrowWeapon : BaseState<GunMachine>
{
    public GunThrowWeapon(GunMachine machine) : base(machine)
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void OnEnter()
    {
        machine.LockState();
        machine.ChangeAnim(PlayerAnimationState.PlayerThrowAnim);
    }

    public override void OnExit()
    {
        
    }

    public override void OnTriggerEvent(StateMachine.TriggerEventType type)
    {
        machine.UnlockState();
        machine.ChangeState(machine.IdleState);
    }

    public override void Update()
    {
        
    }
}
