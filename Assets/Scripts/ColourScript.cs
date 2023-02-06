using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourScript : MonoBehaviour
{
    [SerializeField] private Color32 carColour;

    public Color32 CarColur
    {
        get => carColour;
        set => carColour = value;
    }
}
