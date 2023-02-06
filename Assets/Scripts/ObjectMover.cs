using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{

    [SerializeField] private Vector2 mainStartPoint;
    [SerializeField] private Vector2 mainEndPoint;
    [SerializeField] private RectTransform mainTab;
    [Range(0,5)]
    [SerializeField] private float timeDelay;


    private void Start()
    {
        StartPhase();
    }

    void StartPhase()
    {
        mainTab.DOAnchorPos(mainStartPoint, timeDelay, true);
        StartCoroutine(Deactivate());

    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(timeDelay);
        mainTab.gameObject.SetActive(false);
    }


}
