using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeUnits : MonoBehaviour
{
    [SerializeField] private List<Transform> balloonPos = new List<Transform>();
    [SerializeField] private GameObject[] balloons = new GameObject[4];
   
    public void RandomizePlayer()
    {
        List<Transform> newBalloonPos = ShuffleList.ShuffleListItems<Transform>(balloonPos);

        for (int i = 0; i < balloonPos.Count; i++)
        {
            balloons[i].transform.position = newBalloonPos[i].position;
        }
    }
}
