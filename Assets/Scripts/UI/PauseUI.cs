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

    private bool _isPaused;
    private bool _isAboutToQuit;

    private GameLoop _gameLoop;

    private void Start()
    {
        _gameLoop = FindObjectOfType<GameLoop>();
    }

    private void PauseGame()
    {
        _pauseScreen.SetActive(true);
        _isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
        _gameLoop.TransitionToPause();
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

    //TODO Fix Bug where ESC from Exit Confirmation screen exits the pause screen
    //TODO Fix Bug where ESC doesn't even work nor does it pause the game
    private void OnPause(InputValue value)
    {
        if (!_isPaused)
            PauseGame();
        else if (_isPaused && _isAboutToQuit)
            LeaveQuitConfirmationScreen();
        else if (_isPaused && !_isAboutToQuit)
            ContinueGame();
    }
}
