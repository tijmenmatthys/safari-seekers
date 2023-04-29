using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private GameOverScreenUI _gameOverScreenUI;

    private float _gameTimer;
    private float _totalTimer;
    private float _idleTimer;
    private bool _isIdle;
    private bool _isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverScreenUI = FindObjectOfType<GameOverScreenUI>();
        _gameTimer = _startingTime;
        _totalTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOver)
        {
            UpdateTimers();
            UpdateTimeUI();
            CheckIdle();
            CheckGameOver();
        }
    }

    private void UpdateTimers()
    {
        _gameTimer -= Time.deltaTime;
        _totalTimer += Time.deltaTime;
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

    //This should invoke an event later down the line
    private void CheckGameOver()
    {
        if (_gameTimer <= 0)
        {
            _isGameOver = true;
            _gameOverScreenUI.ShowGameOverScreen((int)_totalTimer, 5);
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

    public void ReturnToMainMenu()
    {
        StartCoroutine(LoadMainMenuScene());
    }

    IEnumerator LoadMainMenuScene()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(0);
        while (!asyncload.isDone)
        {
            yield return null;
        }
    }
}
