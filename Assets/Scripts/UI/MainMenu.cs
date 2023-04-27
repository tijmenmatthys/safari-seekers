using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuObject, instructionsMenuObject, animalGuideMenuObject;
    public GameObject mainMenuFirstButton, instructionsFirstButton, instructionsClosedButton, animalGuideFirstButton, animalGuideClosedButton;

    [SerializeField]
    private Button _instructionButton;
    [SerializeField]
    private Button _animalGuideButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_instructionButton.IsActive()) 
                _instructionButton.onClick?.Invoke();
            if (_animalGuideButton.IsActive())
                _animalGuideButton.onClick?.Invoke();
        }
    }
    public void PlayGame()
    {
        Debug.Log("Play the Game");
    }

    public void QuitGame()
    {
        Debug.Log("Exit the Game");
        Application.Quit();
    }

    public void OpenInstructionsMenu()
    {
        mainMenuObject.SetActive(false);
        instructionsMenuObject.SetActive(true);
        animalGuideMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructionsFirstButton);
    }

    public void OpenAnimalGuideMenu()
    {
        mainMenuObject.SetActive(false);
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(animalGuideFirstButton);
    }

    public void CloseInstructionsMenu()
    {
        mainMenuObject.SetActive(true);
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructionsClosedButton);
    }

    public void CloseAnimalGuideMenu()
    {
        mainMenuObject.SetActive(true);
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(animalGuideClosedButton);
    }
}
