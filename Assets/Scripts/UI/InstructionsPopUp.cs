using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionsPopUp : MonoBehaviour
{
    [SerializeField]
    private float _timeTillInstructionsPopUp;

    public UnityEvent ShowInstructionPopUp;
    public UnityEvent HideInstructionPopUp;

    private float _idleTimer;
    private bool _isIdle, _popUpIsActive;


    // Update is called once per frame
    void Update()
    {
        CheckIdle();
    }

    public void CheckIdle()
    {
        if (_isIdle)
        {
            _idleTimer += Time.deltaTime;
            if (_idleTimer > _timeTillInstructionsPopUp && !_popUpIsActive)
            {
                Debug.Log("Go");
                ShowInstructionPopUp?.Invoke();
                _popUpIsActive = true;
            }
        }
    }

    public void StartIdleTimer()
    {
        _isIdle = true;
    }

    public void ResetIdleTimer()
    {
        _idleTimer = 0;
        _isIdle = false;
        _popUpIsActive = false;
        HideInstructionPopUp?.Invoke();
    }
}
