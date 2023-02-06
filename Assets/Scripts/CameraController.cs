using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [FormerlySerializedAs("yMin")] [SerializeField] private float xMin;
    [FormerlySerializedAs("yMax")] [SerializeField] private float xMax;
    [FormerlySerializedAs("yValue")] [SerializeField] private float xValue;
    

    private void Update()
    {
        xValue = Mathf.Clamp(player.position.x,xMin,xMax);
        transform.position = new Vector3( xValue, transform.position.y,transform.position.z);
    }
}
