using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        //Replace with code once proper GameState changes are made
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
                PauseGame();
            else if (_isPaused && _isAboutToQuit)
                LeaveQuitConfirmationScreen();
            else
                ContinueGame();
        }
    }

    private void PauseGame()
    {
        _pauseScreen.SetActive(true);
        _isPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_pauseFirstButton);
    }

    public void ContinueGame()
    {
        _pauseScreen.SetActive(false);
        _isPaused = false;
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
}
