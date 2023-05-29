using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverScreenUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private TMP_Text _guessText;
    [SerializeField]
    private TMP_Text _nextMedalText;
    [SerializeField]
    private TMP_Text _medalText;

    [SerializeField]
    private Image _medalImage;
    [SerializeField]
    private Sprite _bronzeMedal;
    [SerializeField]
    private Sprite _silverMedal;
    [SerializeField]
    private Sprite _goldMedal;
    [SerializeField]
    private Sprite _platniumMedal;
    [SerializeField]
    private GameObject _glow;


    [SerializeField]
    private GameObject _gameOverFirstButton;

    public UnityEvent OnGameOver;

    private bool _gameOver = false;

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
            _nextMedalText.text = SetMedals(score, totalGuesses);

            _gameOver = true;
        }
    }

    public void HideGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }

    private string SetMedals(int score, int totalGuesses)
    {
        if (score < 5)
        {
            _glow.SetActive(false);
            _medalImage.sprite = null;
            _medalImage.gameObject.SetActive(false);
            _medalText.text = "No Medal";
            return "5+ Correct Guesses for Bronze!";
        }
        else if (score < 10)
        {
            _medalImage.sprite = _bronzeMedal;
            _medalImage.gameObject.SetActive(true);
            _glow.SetActive(true);
            _medalText.text = "Bronze Medal";
            return "10+ Correct Guesses for Silver!";
        }
        else if (score < 20)
        {
            _medalImage.sprite = _silverMedal;
            _medalImage.gameObject.SetActive(true);
            _glow.SetActive(true);
            _medalText.text = "Silver Medal";
            return "20+ Correct Guesses for Gold!";
        }
        else if (score >= 20 && totalGuesses != score)
        {
            _medalImage.sprite = _goldMedal;
            _medalImage.gameObject.SetActive(true);
            _glow.SetActive(true);
            _medalText.text = "Gold Medal";
            return "20+ Perfect Correct Guesses for Platinum!";
        }
        else
        {
            _medalImage.sprite = _platniumMedal;
            _medalImage.gameObject.SetActive(true);
            _medalText.text = "Platinum Medal";
            return "You are an Animal Master!";
        }
    }
}
