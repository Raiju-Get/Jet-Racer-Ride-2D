using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRemover : MonoBehaviour
{
    [SerializeField] GameObject[] clouds = new GameObject[12];
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    [SerializeField] private float cloudSpeed;
    void Update()
    {
       StartUp(); 
    }

    void StartUp()
    {
       
        for (int i = 0; i < clouds.Length; i++)
        {
            if (clouds[i].transform.position.x <= endX)
            {
                clouds[i].transform.position = new Vector2(startX, clouds[i].transform.position.y);
            }
            clouds[i].transform.position += Vector3.left*cloudSpeed*Time.deltaTime;
        } 
    }
}
