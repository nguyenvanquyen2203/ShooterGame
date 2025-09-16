using UnityEngine;
public enum PauseGameAction
{
    Pause,
    Resume
}
public class PauseGameController : Subject<PauseGameAction>
{
    private static PauseGameController instance;
    public static PauseGameController Instance { get { return instance; } }
    private PauseGameAction pauseState;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pauseState = PauseGameAction.Resume;
    }
    public void PauseAction()
    {
        if (pauseState == PauseGameAction.Pause) pauseState = PauseGameAction.Resume;
        else pauseState = PauseGameAction.Pause;
        NotifyObserver(pauseState);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseAction();
    }
}
