using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDeactivator : MonoBehaviour
{
   [SerializeField] private List<Button> buttonList = new List<Button>();
   [SerializeField] private float disableTimer;

   public void PunishPlayer()
   {
      StartCoroutine(DisableButtons());
   }
   IEnumerator DisableButtons()
   {
      foreach (var button in buttonList)
      {
         button.interactable = false;
      }
      yield return new WaitForSeconds(disableTimer);
      
      ActivateButtons();
   }

   public void ActivateButtons()
   {
      foreach (var button in buttonList)
      {
         button.interactable = true;
      }
   }
}
