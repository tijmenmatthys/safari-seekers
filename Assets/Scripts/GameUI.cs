using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField]
    private float _startingTime;

    [SerializeField]
    private TextMeshProUGUI _timeUI;

    [SerializeField]
    private float _timeTillInstructionsPopUp;
    [SerializeField]
    private GameObject _instructionsPopUp;

    private float _gameTimer;
    private float _idleTimer;
    private bool _isIdle;

    // Start is called before the first frame update
    void Start()
    {
        _gameTimer = _startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        _gameTimer -= Time.deltaTime;
        UpdateTimeUI();
        CheckIdle();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (_gameTimer <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void UpdateTimeUI()
    {
        int seconds = (int)(_gameTimer % 60);
        int minutes = (int)(_gameTimer / 60);

        _timeUI.text = $"{minutes:00}:{seconds:00}";
    }

    public void CheckIdle()
    {
        if ( _isIdle )
        {
            _idleTimer += Time.deltaTime;
            Debug.Log(_idleTimer);
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
