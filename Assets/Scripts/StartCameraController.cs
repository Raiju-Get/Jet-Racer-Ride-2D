using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class StartCameraController : MonoBehaviour
{
    [SerializeField] private Camera cameraRef;
    [SerializeField] private Vector3 startPosition;
    [Range(0, 5)] 
    [SerializeField] private float duration;
    [SerializeField] private GameObject UI;

    public float Duration
    {
        get => duration;
    }

    public void MoveCamera()
    {
       
        cameraRef.transform.DOMove(startPosition, duration);
        StartCoroutine(SetActive());
    }
    

    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(duration);
        cameraRef.GetComponent<CameraController>().enabled = true;
        UI.SetActive(true);
      //  this.gameObject.SetActive(false);
      
    }

    public void ResetPlayer()
    {
        cameraRef.GetComponent<CameraController>().enabled = true;
        UI.SetActive(true);
    }
}
