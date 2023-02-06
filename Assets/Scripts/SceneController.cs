using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private RectTransform title;
    [SerializeField] private float amplitude;

    void Update()
    {
        ShakeUp();
    }

    void ShakeUp()
    {
        title.position = new Vector3(title.position.x, title.position.y + Mathf.Sin(Time.time) *( amplitude/1000),title.position.z);
    }
}
