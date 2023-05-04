
public class PausedState : State<States>
{
    private PauseUI _pauseLogic;

    public override void OnEnter()
    {
        InitalizeReferences();
        _pauseLogic.InPauseState();
    }

    private void InitalizeReferences()
    {
        _pauseLogic = UnityEngine.Object.FindObjectOfType<PauseUI>();
    }

    public override void OnExit()
    {
        _pauseLogic.ExitPauseState();
    }
}
