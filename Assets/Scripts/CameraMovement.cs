using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2.0f;
    public Transform Player;


    void Update()
    {
        
        transform.position += Vector3.up * cameraSpeed * Time.deltaTime;

    }
}
