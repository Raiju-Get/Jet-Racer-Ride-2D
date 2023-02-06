using Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{

  [SerializeField] private string correctAnswer;
  [SerializeField] private GameManager gameManager;
  [SerializeField] private AudioPlayer audioPlayer;
  [SerializeField] private AudioClip audioClipCorrect;
  [SerializeField] private AudioClip audioClipIncorrect;
  [SerializeField] private ButtonDeactivator buttonDeactivation;


  public void GetAnswer(TextMeshProUGUI answer)
  {
    
    if (answer.text == correctAnswer)
    { 
      if (gameManager.isTutorial)
      {
        
        gameManager.CorrectAnswerPointer.SetActive(false);
        buttonDeactivation.ActivateButtons();
        gameManager.TutorialText.gameObject.SetActive(false);
        gameManager.isTutorial = false;
        Time.timeScale = 1;
        
      }

     
      gameManager.PlayState.RefreshState(gameManager, true);
      audioPlayer.Play(audioClipCorrect);
    
    }
    else
    {

      gameManager.PlayState.RefreshState(gameManager, false);
      audioPlayer.Play(audioClipIncorrect
      );
    }
    
  }

  public void GetAnswerString(string answer)
  {
    correctAnswer = answer;
  }
}
