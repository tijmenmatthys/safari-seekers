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

        Sound s = Array.Find(sounds, sound => sound.name == "Running");
        if (s != null)
            s.source.enabled = false;
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

    public void PlaySpringSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Spring");
        s.source.Play();
    }

    public void PlayCrumblingSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Crumbling");
        s.source.Play();
    }

    public void PlayAnimalSelectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "AnimalSelect");
        s.source.Play();
    }

    public void PlayTimePickupSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "TimePickup");
        s.source.Play();
    }

    public void PlayCorrectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Correct");
        s.source.Play();
    }

    public void PlayWrongSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wrong");
        s.source.Play();
    }

    public void PlayGameOverSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "GameOver");
        s.source.Play();
    }
}
