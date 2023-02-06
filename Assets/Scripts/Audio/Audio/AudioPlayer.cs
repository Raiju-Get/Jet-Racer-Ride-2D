using System;
using UnityEngine;
using UnityEngine.Video;

namespace Script
{
    public class AudioPlayer : MonoBehaviour
    {
       
        [SerializeField] private AudioSource audioSource;

        public void Play(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void PlayLoop(AudioClip audioClip)
        {
            audioSource.loop = true;
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void DisableLoop()
        {
            audioSource.loop = false;
            audioSource.Stop();
        }
    }
}