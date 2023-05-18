using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private float _timeTillInstructionsPopUp;

    [SerializeField]
    private GameObject _instructionsPopUp;

    public UnityEvent OnInstructionPopUp;

    private float _idleTimer;
    private bool _isIdle;


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
            if (_idleTimer > _timeTillInstructionsPopUp)
            {
                _instructionsPopUp.SetActive(true);
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
        _instructionsPopUp.SetActive(false);
    }
}
