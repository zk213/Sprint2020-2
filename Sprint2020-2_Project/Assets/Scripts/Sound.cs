using UnityEngine.Audio;
using UnityEngine;

//Another script that i learnd from Brackeys
//Used for letting the audio manager script to know what it needs know
[System.Serializable]


public class Sound
{

    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float vloume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}