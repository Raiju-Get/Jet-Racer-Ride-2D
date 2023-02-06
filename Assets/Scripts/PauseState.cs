using UnityEngine;

public class PauseState : GameStateMachine
{
    public override void EnterState(GameManager manager)
    {
        Debug.Log("Stopped");
        Time.timeScale = 0;
    }

    public override void RefreshState(GameManager manager, bool correct)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGameState(GameManager manager)
    {
       
    }

    public override void TransitionState(GameManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void EndState(GameManager manager)
    {
        throw new System.NotImplementedException();
    }
}
