using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using static UnityEngine.Rendering.DebugUI;

public class GameOverScreenUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private TMP_Text _timeText;
    [SerializeField]
    private TMP_Text _scoreText;

    public void ShowGameOverScreen(float time, int score)
    {
        _gameOverScreen.SetActive(true);
        int m = (int)(time / 60);
        int s = (int)(time % 60);
        _timeText.text = $"Total Playtime: " + $"{m:00}:{s:00}"; ;
        _scoreText.text = $"Correct Guesses: {score}";
    }

    public void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }
}
