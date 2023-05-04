using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spring : MonoBehaviour
{
    public UnityEvent OnActivate;

    private bool _isIdle = true;

    public bool TryJump()
    {
        if (!_isIdle) return false;

        OnActivate?.Invoke();
        _isIdle = false;
        return true;
    }

    public void ResetJump()
    {
        _isIdle = true;
    }
}
