using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrumblingPlatform : MonoBehaviour
{
    [SerializeField] private float _timeUntilCrumbleWarning = 2;
    [SerializeField] private float _timeUntilCrumble = 3;
    [SerializeField] private float _timeUntilRespawn = 3;

    public UnityEvent OnCrumbleWarn;
    public UnityEvent OnCrumble;
    public UnityEvent OnRespawn;

    private Collider _collider;
    private CrumblingPlatformState _state
        = CrumblingPlatformState.Idle;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void OnPlayerStay()
    {
        if (_state != CrumblingPlatformState.Idle) return;

        StartCoroutine(Crumble());
        StartCoroutine(WarnCrumble());
        _state = CrumblingPlatformState.Crumbling;
    }

    public void OnPlayerExit()
    {
    }

    private IEnumerator WarnCrumble()
    {
        yield return new WaitForSeconds(_timeUntilCrumbleWarning);
        OnCrumbleWarn?.Invoke();
    }

    private IEnumerator Crumble()
    {
        yield return new WaitForSeconds(_timeUntilCrumble);

        OnCrumble?.Invoke();
        _collider.enabled = false;
        _state = CrumblingPlatformState.Respawning;
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(_timeUntilRespawn);

        _collider.enabled = true;
        OnRespawn?.Invoke();
        _state = CrumblingPlatformState.Idle;
    }
}

public enum CrumblingPlatformState
{
    Idle,
    Crumbling,
    Respawning
}
