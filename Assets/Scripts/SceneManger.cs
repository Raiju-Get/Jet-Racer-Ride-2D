using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManger : MonoBehaviour
{
   public void Restart()
   {
      Time.timeScale = 1;
      int currentLevel = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentLevel);
   }
}
