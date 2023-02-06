using Script;
using TMPro;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private AudioClip won;
    [SerializeField] private AudioClip lose;
    
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        manager.WinnerSprite = col.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        manager.WinnerName.text = col.gameObject.GetComponentInChildren<TextMeshPro>().text;
        if (col.gameObject.CompareTag("Player"))
        {
            manager.SwitchState(manager.WinState);
            audioPlayer.Play(won);
        }
        else
        {
            manager.SwitchState(manager.LoseState);
            audioPlayer.Play(lose);
        }
    }
}
