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
    public void LoudenRunSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Running");
        s.source.volume = 0.9f;
    }

    public void SilenceRunSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Running");
        s.source.volume = 0;
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

    public void LoudenWadeSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wading");
        s.source.volume = 0.7f;
    }
    public void SilenceWadeSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wading");
        s.source.volume = 0;
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
    public void PlaySmallTimePickupSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "TimePickup");
        UpdatePitch(s, _originalPitch - 0.1f);
        s.source.Play();
    }

    public void PlayMediumTimePickupSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "TimePickup");
        UpdatePitch(s, _originalPitch);
        s.source.Play();
    }

    public void PlayBigTimePickupSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "TimePickup");
        UpdatePitch(s, _originalPitch + 0.1f);
        s.source.Play();
    }

    public void PlayCorrectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Correct");
        UpdatePitch(s, 1f);
        s.source.Play();
    }

    public void PlayWrongSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wrong");
        UpdatePitch(s, 1f);
        s.source.Play();
    }

    public void PlayFinalCorrectSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Correct");
        UpdatePitch(s, _originalPitch + 0.15f);
        s.source.Play();
    }

    public void PlayFinalWrongSFX()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Wrong");
        UpdatePitch(s, _originalPitch - 0.15f);
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

    private void UpdatePitch(Sound sound, float value)
    {
        sound.source.pitch = value;
    }
}
