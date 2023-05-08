using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loops;
        }
    }

    public void PlayJumpSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Jump");
        s.source.Play();
    }

    public void PlayRunSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Running");
        s.source.enabled = true;
    }

    public void StopRunSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Running");
        s.source.enabled = false;
    }
}
