using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuObject, instructionsMenuObject, animalGuideMenuObject, creditsMenuObject;
    public GameObject mainMenuFirstButton, instructionsFirstButton, instructionsClosedButton, animalGuideFirstButton, animalGuideClosedButton, creditsFirstButton, creditsClosedButton;
    [SerializeField]
    private Button _instructionButton;
    [SerializeField]
    private Button _animalGuideButton;
    [SerializeField]
    private Button _creditsButton;


    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_instructionButton.IsActive()) 
                _instructionButton.onClick?.Invoke();
            if (_animalGuideButton.IsActive())
                _animalGuideButton.onClick?.Invoke();
            if (_creditsButton.IsActive())
                _creditsButton.onClick?.Invoke();
        }
        */
    }
    public void PlayGame()
    {
        Debug.Log("Play the Game");
        StartCoroutine(LoadGameScene());
    }

    public void QuitGame()
    {
        Debug.Log("Exit the Game");
        Application.Quit();
    }

    public void OpenInstructionsMenu()
    {
        instructionsMenuObject.SetActive(true);
        animalGuideMenuObject.SetActive(false);
        creditsMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructionsFirstButton);
    }

    public void OpenAnimalGuideMenu()
    {
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(true);
        creditsMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(animalGuideFirstButton);
    }

    public void OpenCreditsMenu()
    {
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(false);
        creditsMenuObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);

    }

    public void CloseInstructionsMenu()
    {
        mainMenuObject.SetActive(true);
        animalGuideMenuObject.SetActive(false);
        creditsMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(instructionsClosedButton);
    }

    public void CloseAnimalGuideMenu()
    {
        mainMenuObject.SetActive(true);
        instructionsMenuObject.SetActive(false);
        creditsMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(animalGuideClosedButton);
    }

    public void CloseCreditsMenu()
    {
        mainMenuObject.SetActive(true);
        instructionsMenuObject.SetActive(false);
        animalGuideMenuObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsClosedButton);

    }

    public void OnPause()
    {
        if (instructionsMenuObject.activeSelf && _instructionButton.interactable)
            _instructionButton.onClick?.Invoke();
        else if (animalGuideMenuObject.activeSelf && _animalGuideButton.interactable)
            _animalGuideButton.onClick?.Invoke();
        else if (creditsMenuObject.activeSelf && _creditsButton.interactable)
            _creditsButton.onClick?.Invoke();

    }


    IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
