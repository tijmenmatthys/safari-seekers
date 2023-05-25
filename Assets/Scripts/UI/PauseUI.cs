using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PauseUI : MonoBehaviour
{
    public UnityEvent OnPauseGame;
    public UnityEvent OnResumeGame;
    [SerializeField]
    private GameObject _pauseScreen;

    [SerializeField]
    private Button leaveQuitConfirmationButton;

    [SerializeField]
    private Button controlsBackButton, _continueButton;

    [SerializeField]
    private GameObject _pauseFirstButton, _exitFirstButton, _exitLeaveButton, _controlsFirstButton, _controlsLeaveButton;

    private bool _isPaused, _inReviewOrOverScreen;
    private bool _inExitConfirmationScreen, _inControlsScreen;
    private bool _canExitMenu = true;

    private GameLoop _gameLoop;
    private InputAction _pauseGame;

    private void Start()
    {
        MainInputActions mainInputActions = new MainInputActions();
        mainInputActions.UI.Enable();
        mainInputActions.UI.Pause.performed += OnPause;

        _gameLoop = FindObjectOfType<GameLoop>();
    }

    public void PauseGame()
    {
        if (!_isPaused && _canExitMenu)
        {
            CannotExitMenu();
            _pauseScreen.SetActive(true);
            _isPaused = true;
            OnPauseGame?.Invoke();
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
            _gameLoop.TransitionToPause();
            _inReviewOrOverScreen = false;
        }
    }

    private void InvokeContinueButton()
    {
        if (_canExitMenu)
        {
            CannotExitMenu();
            _continueButton.onClick?.Invoke();
            OnResumeGame?.Invoke();
        }
    }

    public void ContinueGame()
    {
        _isPaused = false;
        _gameLoop.TransitionToPlaying();
    }

    private void LeaveQuitConfirmationScreen()
    {
        if (_canExitMenu)
        {
            CannotExitMenu();
            leaveQuitConfirmationButton.onClick?.Invoke();
        }
    }

    private void LeaveControlsScreen()
    {
        if (_canExitMenu)
        {
            CannotExitMenu();
            controlsBackButton.onClick?.Invoke();
        }
    }

    public void OnAboutToQuitScreen()
    {
        _inExitConfirmationScreen = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_exitFirstButton);
    }

    public void ExitAboutToQuitScreen()
    {
        _inExitConfirmationScreen = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_exitLeaveButton);
    }

    public void OnControlsScreen()
    {
        _inControlsScreen = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_controlsFirstButton);
    }

    public void ExitControlsScreen()
    {
        _inControlsScreen = false;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_controlsLeaveButton);
    }

    private void OnPause(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed ESC");
        if (!_inReviewOrOverScreen)
        {
            if (!_isPaused)
                PauseGame();
            else if (_isPaused && _inExitConfirmationScreen)
                LeaveQuitConfirmationScreen();
            else if (_isPaused && _inControlsScreen)
                LeaveControlsScreen();
            else if (_isPaused && !_inExitConfirmationScreen && !_inControlsScreen)
                InvokeContinueButton();
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

    public void CanExitMenu()
    {
        _canExitMenu = true;
    }

    public void CannotExitMenu()
    {
        _canExitMenu = false;
    }
}
