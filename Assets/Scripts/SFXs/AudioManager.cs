using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private float _deviation = 0.05f;
    [SerializeField]
    private float _originalPitch = 1f;

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

        Sound wade = Array.Find(sounds, sound => sound.name == "Wading");
        if (wade != null)
            wade.source.enabled = false;
    }

    public void PlayJumpSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Jump");
        UpdatePitch(s);
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

    public void PlayWadeSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wading");
        s.source.enabled = true;
    }

    public void StopWadeSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wading");
        s.source.enabled = false;
    }

    public void PlaySpringSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Spring");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayCrumblingSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Crumbling");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayAnimalSelectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "AnimalSelect");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayTimePickupSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "TimePickup");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayCorrectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Correct");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayWrongSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wrong");
        UpdatePitch(s);
        s.source.Play();
    }

    public void PlayGameOverSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "GameOver");
        UpdatePitch(s);
        s.source.Play();
    }

    private void UpdatePitch(Sound sound)
    {
        sound.source.pitch = _originalPitch;
        float randomPitchDeviation = Random.Range(-_deviation, _deviation);
        sound.source.pitch += randomPitchDeviation;
    }

    private void UpdatePitch(Sound sound, float multiplier)
    {
        sound.source.pitch = _originalPitch;
        float randomPitchDeviation = Random.Range(-_deviation, _deviation);
        sound.source.pitch += randomPitchDeviation;
    }
}
