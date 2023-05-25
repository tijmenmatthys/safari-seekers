using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Xml.Schema;
using UnityEngine.ProBuilder.MeshOperations;

public class GameOverScreenUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private TMP_Text _guessText;
    [SerializeField]
    private TMP_Text _nextMedalText;

    [SerializeField]
    private GameObject _gameOverFirstButton;

    public UnityEvent OnGameOver;

    private bool _gameOver = false;

    private void Start()
    {
    }

    public void ShowGameOverScreen(int score, int totalGuesses)
    {
        if (!_gameOver)
        {
            FindObjectOfType<MusicManager>()?.PlayMenuMusic();
            OnGameOver?.Invoke();
            _gameOverScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_gameOverFirstButton);
            _guessText.text = $"Correct Guesses: {score} out of {totalGuesses}";
            _nextMedalText.text = GetMedalText(score, totalGuesses);

            _gameOver = true;
        }
    }

    public void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }

    private string GetMedalText(int score, int totalGuesses)
    {
        if (score < 5)
            return "5 or More Correct Guesses for Bronze!";
        else if (score < 10)
            return "10 or More Correct Guesses for Silver!";
        else if (score < 20)
            return "20 or More Correct Guesses for Gold!";
        else if (score >= 20 && totalGuesses == score)
            return "20 or More Perfect Correct Guesses for Platnium!";
        else
            return "You are an Animal Master!";
    }
}
