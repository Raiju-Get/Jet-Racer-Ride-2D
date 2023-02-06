using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAudio : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField]AudioSource audioSource;
    
    [Header(("Audio List"))]
    [SerializeField] List<AudioClip> gameSounds = new List<AudioClip>();
  
    
   
}


