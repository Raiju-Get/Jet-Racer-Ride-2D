using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    public class AccessibilityManager : VisualSettings
    {
        [SerializeField] private Slider brightnessHandler;
        [SerializeField] private Slider contrastHandler;
        [SerializeField] private Slider saturationHandler;
        [SerializeField] private float minVal;
        
        private void HandleColorSettings(string setting, float value)
        {
            switch (setting) 
            {
                case "brightness":
                    brightnessHandler.value = value;
                    break;
                case "contrast":
                    contrastHandler.value = value;
                    break;
                case "saturation":
                    saturationHandler.value = value;
                    break;
            }
        }
        
        private void Start()
        {
            if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
            {
                //Set first time opening to false
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
                brightnessHandler.value = 1f;
                contrastHandler.value = 1f;
                saturationHandler.value = 1f;
                SaveSliders();
            }
            else
            {
                
                brightnessHandler.value = PlayerPrefs.GetFloat("Brightness");
                contrastHandler.value = PlayerPrefs.GetFloat("Contrast");
                saturationHandler.value = PlayerPrefs.GetFloat("Saturation");
                
            }
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (_Material)
            {
                _Material.SetFloat("_Brightness", brightnessHandler.value);
                _Material.SetFloat("_Saturation", saturationHandler.value);
                _Material.SetFloat("_Contrast", contrastHandler.value);
                Graphics.Blit(source, destination, _Material);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }

        public void SaveBrightness()
        {
            PlayerPrefs.SetFloat("Brightness", brightnessHandler.value);
        }

        public void SaveContrast()
        {
            PlayerPrefs.SetFloat("Contrast", contrastHandler.value); 
        }

        public void SaveSaturation()
        {
            PlayerPrefs.SetFloat("Saturation", saturationHandler.value);
        }

      private void SaveSliders()
        {
            PlayerPrefs.SetFloat("Brightness", brightnessHandler.value);
            PlayerPrefs.SetFloat("Contrast", contrastHandler.value);
            PlayerPrefs.SetFloat("Saturation", saturationHandler.value);
        }
    }

