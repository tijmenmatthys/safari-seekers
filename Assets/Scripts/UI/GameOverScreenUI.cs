using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameOverScreenUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private TMP_Text _timeText;
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private GameObject _gameOverFirstButton;

    public UnityEvent OnGameOver;

    private bool _gameOver = false;

    private void Start()
    {
    }

    public void ShowGameOverScreen(float time, int score)
    {
        if (!_gameOver)
        {
            OnGameOver?.Invoke();
            _gameOverScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_gameOverFirstButton);
            int m = (int)(time / 60);
            int s = (int)(time % 60);
            _timeText.text = $"Total Playtime: " + $"{m:00}:{s:00}"; ;
            _scoreText.text = $"Correct Guesses: {score}";
            _gameOver = true;
        }
    }

    public void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }
}
