using UnityEngine;

public class WinState : GameStateMachine
{
    public override void EnterState(GameManager manager)
    {
        Debug.Log("You Win");
        Time.timeScale = 0;
        manager.BalloonUI.sprite = manager.WinnerSprite;
        manager.PlayerUI.SetActive(false);
        manager.Winner.SetActive(true);
        manager.Blocker.SetActive(true);
        foreach (var t in manager.RivalScript)
        {
            t.StopVelocity();
        }
        manager.PlayerController.StopPlayerVelocity();
    }

    public override void RefreshState(GameManager manager,bool correct)
    {
       
    }

    public override void UpdateGameState(GameManager manager)
    {
      
      
    }

    public override void TransitionState(GameManager manager)
    {
        
    }

    public override void EndState(GameManager manager)
    {
       
    }
}
