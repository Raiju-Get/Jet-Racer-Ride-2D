using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable]
public struct RacerData
{
    public string name;
    public float location;
    public Color32 carColour;
}
public class PlaceTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textPlace = new TextMeshProUGUI[4];
    [SerializeField] private TextMeshProUGUI[] textPlaceLeaderBoarder = new TextMeshProUGUI[4];
    [SerializeField] private GameObject[] playerGameObject = new GameObject[4];
    [SerializeField] public RacerData[] racerDataArray = new RacerData[4];
    [SerializeField] public string[] stringArray = new String[4];
    [SerializeField] private Image[] carColoursImage = new Image[4];
    [SerializeField] private Image[] carColoursImageLeaderBoarder = new Image[4];
    [SerializeField] private Color32[] carColours = new Color32[4];
    

    public void PlacementTracker()
    {
        for (int i = 0; i < playerGameObject.Length; i++)
        {
            racerDataArray[i].name = playerGameObject[i].GetComponentInChildren<TextMeshPro>().text;
            racerDataArray[i].location = playerGameObject[i].transform.position.x;
            racerDataArray[i].carColour = playerGameObject[i].GetComponent<ColourScript>().CarColur;
        }

       var data = racerDataArray.OrderBy(l => l.location);
       Debug.Log(data);
        int iteration = 0;
        
        foreach (var racer in data)
        {
            carColours[iteration] = racer.carColour;
            stringArray[iteration] = racer.name;
            Debug.Log(racer.carColour);
            Debug.Log(racer.name);
            Debug.Log(racer.location);
            iteration++;
        }

        if (iteration >=4)
        {
            iteration = 0;
        }

        int secondIteration = 3;
        for (int i = 0; i < textPlace.Length; i++)
        {
            textPlace[i].text = stringArray[i];
            textPlaceLeaderBoarder[i].text = stringArray[i];
            carColoursImage[i].color = carColours[secondIteration];
            carColoursImageLeaderBoarder[i].color = carColours[secondIteration];
            secondIteration--;
        }
        if (secondIteration <=0)
        {
            secondIteration = 3;
        }
    }
}

    

