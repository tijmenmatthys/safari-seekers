using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class GameOverScreenUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private TMP_Text _timeText;
    [SerializeField]
    private TMP_Text _scoreText;

    public void ShowGameOverScreen(int time, int score)
    {
        _gameOverScreen.SetActive(true);
        _timeText.text = $"Total Playtime: {time} seconds";
        _scoreText.text = $"Correct Guesses: {score}";
    }

    public void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }
}
