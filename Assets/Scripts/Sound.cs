using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public float volume;
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public float minPitch = 1.0f;
    public float maxPitch = 1.0f;

    public float minVolume = 1.0f;
    public float maxVolume = 1.0f;


}
