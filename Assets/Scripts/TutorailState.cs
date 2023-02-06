using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailState : GameStateMachine
{
    
    public override void EnterState(GameManager manager)
    {
        manager.TutorialObject.SetActive(true);
        
    }

    public override void RefreshState(GameManager manager, bool correct)
    {
        
    }

    public override void UpdateGameState(GameManager manager)
    {
        manager.StartTimer -= Time.unscaledDeltaTime;
        if (manager.StartTimer > 0)
        {
            if (manager.StartTimer >= 3)
            {
                manager.StartTimerImage.sprite = manager.NewSprite[0];
            }
            else if (manager.StartTimer is >= 2 and <= 3)
            {
                manager.StartTimerImage.sprite = manager.NewSprite[1];
            }
            else if (manager.StartTimer is >= 1 and <= 2)
            {
                manager.StartTimerImage.sprite = manager.NewSprite[2];
            }
            else if(manager.StartTimer is >= 0 and <= 1)
            {
                manager.StartTimerImage.sprite = manager.NewSprite[3];
            }
        }
        else
        {
            
            manager.PlayerUI.SetActive(true);
            manager.StartTimerImage.gameObject.SetActive(false);
            manager.StartTimerPanel.gameObject.SetActive(false);
            manager.isReset = true;
            manager.SwitchState(manager.PlayState);
            manager.TutorialText.SetActive(true);
            

        }

    }

    public override void TransitionState(GameManager manager)
    {
        
    }

    public override void EndState(GameManager manager)
    {
        
    }
}
