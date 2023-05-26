using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private GameLoop _gameLoop;
    private void Awake()
    {
     _gameLoop = FindObjectOfType<GameLoop>();   
    }
    public void LoadMainMenuScene()
    {
        FindObjectOfType<MusicManager>()?.PlayMenuMusic();
        _gameLoop.TransitionToPlaying();
        StartCoroutine(LoadMenuScene());
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
