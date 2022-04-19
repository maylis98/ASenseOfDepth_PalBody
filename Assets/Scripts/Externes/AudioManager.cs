using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playAwake;
        }
    }

    private void Start()
    {
        //Play("background");
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
