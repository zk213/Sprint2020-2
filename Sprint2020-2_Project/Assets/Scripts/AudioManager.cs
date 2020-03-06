using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //I learned this script from a Youtuber called Brackeys
    //And i followed his video and typed the code

    private static bool started = false;

    //Set a list to store sounds
    public Sound[] sounds;

    void Start()
    {
        if (started == false)
        {
            FindObjectOfType<AudioManager>().Play("BGMLoop", gameObject);
            started = true;
        }      

        //The sound that i need to play from the beginning of the game which is the BGM
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //Set audio properties through code
        //foreach (Sound s in sounds)
        //{
        //    s.source = gameObject.AddComponent<AudioSource>();
        //    s.source.clip = s.clip;
        //    s.source.volume = s.vloume;
        //    s.source.pitch = s.pitch;
        //    s.source.loop = s.loop;
        //}
    }

    //The code for looking for sound when i need them
    public void Play(string name, GameObject obj)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        AudioSource aSource = obj.GetComponent<AudioSource>();
        if(aSource == null)
        {
            aSource = obj.AddComponent<AudioSource>();
        }

        aSource.clip = s.clip;
        aSource.volume = s.vloume;
        aSource.pitch = s.pitch;
        aSource.loop = s.loop;
        aSource.Play();
    }
}
