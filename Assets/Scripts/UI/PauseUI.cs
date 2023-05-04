using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseScreen;

    [SerializeField]
    private Button leaveQuitConfirmationButton;

    [SerializeField]
    private GameObject _pauseFirstButton, _exitFirstButton, _exitLeaveButton;

    private bool _isPaused, _inReviewOrOverScreen;
    private bool _isAboutToQuit;

    private GameLoop _gameLoop;
    private InputAction _pauseGame;

    private void Start()
    {
        MainInputActions mainInputActions = new MainInputActions();
        mainInputActions.UI.Enable();
        mainInputActions.UI.Pause.performed += OnPause;

        _gameLoop = FindObjectOfType<GameLoop>();
    }

    private void PauseGame()
    {
        if (!_isPaused)
        {
            _pauseScreen.SetActive(true);
            _isPaused = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
            _gameLoop.TransitionToPause();
            _inReviewOrOverScreen = false;
        }
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        _pauseScreen.SetActive(false);
        _isPaused = false;
        _gameLoop.TransitionToPlaying();
    }

    private void LeaveQuitConfirmationScreen()
    {
        leaveQuitConfirmationButton.onClick?.Invoke();
        _isAboutToQuit = false;
    }

    public void OnAboutToQuitScreen()
    {
        _isAboutToQuit = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_exitFirstButton);
    }

    public void ExitAboutToQuitScreen()
    {
        _isAboutToQuit = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_exitLeaveButton);
    }
    private void OnPause(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed ESC");
        if (!_inReviewOrOverScreen)
        {
            if (!_isPaused)
                PauseGame();
            else if (_isPaused && _isAboutToQuit)
                LeaveQuitConfirmationScreen();
            else if (_isPaused && !_isAboutToQuit)
                ContinueGame();
        }
    }

    public void InPauseState()
    {
        _inReviewOrOverScreen = true;
    }

    public void ExitPauseState()
    {
        _inReviewOrOverScreen = false;
    }
}
