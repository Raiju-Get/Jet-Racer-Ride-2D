using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BalloonController : MonoBehaviour
{
    
    private Coroutine _tempRacer;
    private static readonly int Squish = Animator.StringToHash("Squish");
    private bool _isRacing;
    [SerializeField]private float timer;
    private float _tempTimer;
    [FormerlySerializedAs("_speedMultiplier")] [SerializeField]private float speedMultiplier;


    private void Start()
    {
        _tempTimer = timer;
    }

    public void BalloonFloat(ref Rigidbody2D balloon, float jumpSpeed , ref float maxVelocity , float velocaity)
    {
        
        if (maxVelocity <= velocaity*speedMultiplier)
        {
            maxVelocity = maxVelocity * speedMultiplier;
        }
       
        balloon.AddForce(new Vector2(jumpSpeed,balloon.velocity.y),ForceMode2D.Impulse);

        
        maxVelocity = maxVelocity / speedMultiplier;

    }

   

    public void SquishBalloon(Animator animator)
    {
        animator.SetTrigger(Squish);
    }

 
}
