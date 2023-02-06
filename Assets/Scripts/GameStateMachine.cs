
public abstract class GameStateMachine
{
    public abstract void EnterState(GameManager manager);
    public abstract void RefreshState(GameManager manager, bool correct);
    public abstract void UpdateGameState(GameManager manager);
    public abstract void TransitionState(GameManager manager);
    public abstract void EndState(GameManager manager);
}
