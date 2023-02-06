
using UnityEngine;

public class PlayState : GameStateMachine
{
  private static readonly int IsDriving = Animator.StringToHash("isDriving");

  public override void EnterState(GameManager manager)
  {
    manager.Blocker.SetActive(false);
    manager.AnswerSet.GetData();
    for (int i = 0; i < manager.CarAnimatorList.Length; i++)
    {
      manager.CarAnimatorList[i].SetBool(IsDriving, true);
    }

  }

  public override void RefreshState(GameManager manager, bool correct)
  {
    if (correct)
    {
      manager.AnswerSet.GetData();
      manager.PlayerController.FlightController();
    }
    else
    {
      manager.AnswerSet.GetData();
      manager.ButtonDeactivator.PunishPlayer();
      
    }
 
  }

  public override void UpdateGameState(GameManager manager)
  {
    if (manager.isReset)
    { 
      manager.PlaceTracker.PlacementTracker();
      manager.Timer -= Time.deltaTime;
      if (manager.Timer <= 0 && manager.CurrentState == manager.PlayState)
      {
        if (!manager.isTutorial)
        {
          foreach (var t in manager.RivalScript)
          {
            t.AiFunction();
          }
          manager.Timer = manager.TempTimer;
        }
      }
    
    
    }
    
  }

  public override void TransitionState(GameManager manager)
  {
   
    Time.timeScale = 1;
  }

  public override void EndState(GameManager manager)
  {
    
  }
}
