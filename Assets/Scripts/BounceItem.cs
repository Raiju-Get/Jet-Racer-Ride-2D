using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BounceItem : MonoBehaviour
{
    //(Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping)
    [SerializeField] private RectTransform bounceItem;
    [SerializeField] private Vector2 endValue;
    [SerializeField] private float jumpPower;
    [SerializeField] private int numJumps;
    [SerializeField] private float duration;
    [SerializeField] private bool snapping;

    private void Start()
    {
        bounceItemFunx();
    }

  
    void bounceItemFunx()
    {
        bounceItem.DOJumpAnchorPos(endValue, jumpPower, numJumps, duration, snapping);

    }
}
