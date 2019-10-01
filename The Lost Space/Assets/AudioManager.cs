using UnityEngine.Audio;
using UnityEngine;
using System;
using Random  = UnityEngine.Random;
public class AudioManager : MonoBehaviour
{
   // public String music[];
    public Sounds[] sounds;
    private Sounds SoundNumber;
    private int nextTrack= 6;
    private bool isPlaying = false;
    public static AudioManager instance; 
    

    void Awake()
    {
        
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
            s.source.spatialBlend = s.SpatialBlend;
            s.source.outputAudioMixerGroup = s.mixer;
        }
       
    }
    void Start()
    {
        SoundNumber = sounds[Random.Range(nextTrack, 12)];
        Play(SoundNumber.name);
    }

    // Update is called once per frame
    public void Play( string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == name);
        s.source.Play();
    }

    private void Update()
    {
       

    }

    
}
