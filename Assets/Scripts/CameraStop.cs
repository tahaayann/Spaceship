using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    public CameraMovement CameraMovement;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            CameraMovement.cameraSpeed = 0;

        }
    }
}
