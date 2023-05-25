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
    [SerializeField] private LayerMask _playerLayerMask;

    public UnityEvent OnCrumbleWarn;
    public UnityEvent OnCrumble;
    public UnityEvent OnRespawn;

    private Collider _collider;
    private Vector3 _colliderExtents;
    private CrumblingPlatformState _state
        = CrumblingPlatformState.Idle;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void Start()
    {
        _colliderExtents = _collider.bounds.extents;
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
        do
            yield return new WaitForSeconds(_timeUntilRespawn);
        while (IsPlayerBlockingRespawn());

        _collider.enabled = true;
        OnRespawn?.Invoke();
        _state = CrumblingPlatformState.Idle;
    }

    private bool IsPlayerBlockingRespawn()
    {
        return Physics.BoxCast(_collider.bounds.center, _colliderExtents,
            Vector3.down, transform.rotation, 1, _playerLayerMask, QueryTriggerInteraction.Collide);
    }
}

public enum CrumblingPlatformState
{
    Idle,
    Crumbling,
    Respawning
}
