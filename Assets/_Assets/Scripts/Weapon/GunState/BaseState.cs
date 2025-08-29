public abstract class BaseState<T> : IState where T : StateMachine
{
    protected T machine;
    public BaseState(T machine)
    {
        this.machine = machine;
    }

    public abstract void FixedUpdate();

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void Update();
    public abstract void OnTriggerEvent(StateMachine.TriggerEventType type);
}