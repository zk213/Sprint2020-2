using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //I learned this script from a Youtuber called Brackeys
    //And i followed his video and typed the code


    //Set a list to store sounds
    public Sound[] sounds;


    void Start()
    {
        //The sound that i need to play from the beginning of the game which is the BGM
    }

    void Awake()
    {
        //Set audio properties through code
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.vloume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //The code for looking for sound when i need them
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
