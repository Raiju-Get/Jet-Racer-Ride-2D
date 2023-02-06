using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectColourScript : MonoBehaviour
{
    [SerializeField] private Color32 correct;
    [SerializeField] private Color32 incorrect;

    public void CorrectColour(Image buttonImage)
    {
        buttonImage.color = correct;
    }

}
