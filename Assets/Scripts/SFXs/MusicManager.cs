using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private float _fadeTime = .5f;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField, Range(0f, 1f)] private float _maxVolume = 1f;

    private AudioSource _menuSource;
    private AudioSource _gameSource;

    private void Awake()
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitSources();

        _menuSource.Play();
    }

    public void PlayGameMusic()
    {
        StartCoroutine(FadeOut(_menuSource));
        StartCoroutine(FadeIn(_gameSource));
    }

    public void PlayMenuMusic()
    {
        StartCoroutine(FadeOut(_gameSource));
        StartCoroutine(FadeIn(_menuSource));
    }

    private IEnumerator FadeOut(AudioSource source)
    {
        while (source.volume > 0)
        {
            source.volume -= Time.fixedDeltaTime / _fadeTime;
            yield return null;
        }
        source.Stop();
        source.volume = _maxVolume;
    }

    private IEnumerator FadeIn(AudioSource source)
    {
        source.volume = 0;
        source.Play();
        while (source.volume < _maxVolume)
        {
            source.volume += Time.fixedDeltaTime / _fadeTime;
            yield return null;
        }
        source.volume = _maxVolume;
    }

    private void InitSources()
    {
        _menuSource = gameObject.AddComponent<AudioSource>();
        _menuSource.clip = _menuMusic;
        _menuSource.loop = true;
        _menuSource.volume = _maxVolume;

        _gameSource = gameObject.AddComponent<AudioSource>();
        _gameSource.clip = _gameMusic;
        _gameSource.loop = true;
        _gameSource.volume = _maxVolume;
    }

}

