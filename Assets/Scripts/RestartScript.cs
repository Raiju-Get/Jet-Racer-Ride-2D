
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject[] resetUI = new GameObject[2];
    [SerializeField] private Rigidbody2D[] cars = new Rigidbody2D[4];
    [SerializeField] private Animator[] carAnimators = new Animator[4];

    public void Restart()
    {
        foreach (var carAnimator in carAnimators)
        {
            carAnimator.Play("Idle");
        }
        cameraController.enabled = false;
        foreach (var t in resetUI)
        {
            t.SetActive(false);
        }

        foreach (var car in cars)
        {
            car.velocity = Vector2.zero;
        }

      

    }

 

 

}
