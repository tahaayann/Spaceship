using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public float destroyTime = 5f;

    void Start()
    {
        Invoke("DestroyObject", destroyTime);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
