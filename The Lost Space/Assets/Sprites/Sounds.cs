﻿using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sounds
{
    
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float SpatialBlend;

    [HideInInspector]
    public AudioSource source;
    public bool Loop;
    public AudioMixerGroup mixer;
}





