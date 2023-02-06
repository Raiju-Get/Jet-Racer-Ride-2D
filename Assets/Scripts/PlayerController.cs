using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private BalloonController balloonController;
    [SerializeField] private Rigidbody2D playPhysic2D;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float sqrMaxVelocity;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorBoost;
    private float _tempVelocity;

    private void Start()
    {
        _tempVelocity = maxVelocity;
    }

    public float MaxVelocity
    {
        get => maxVelocity;
        set => maxVelocity = value;
    }
    private void Awake()
    {
        SetMaxVelocity(maxVelocity);
    }
    

    void SetMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }
    
    private void FixedUpdate()
    {
        var velocity = playPhysic2D.velocity;
        if (velocity.sqrMagnitude>sqrMaxVelocity)
        {
            playPhysic2D.velocity = velocity.normalized * maxVelocity;
        }
    }
    public void FlightController()
    {
        balloonController.BalloonFloat(ref playPhysic2D,jumpForce, ref maxVelocity, _tempVelocity);
        balloonController.SquishBalloon(_animator);
        _animatorBoost.SetTrigger("Boost");

    }

    public void StopPlayerVelocity()
    {
        playPhysic2D.velocity = Vector2.zero;
        
    }


}
