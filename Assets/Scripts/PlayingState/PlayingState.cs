using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayingState : State<States>
{
    private int _animalsFound = 0;
    private Mission _currentMission;

    private PlayerInput _playerInput;
    private PlayerAnimalInteractions _playerAnimalInteractions;
    private MissionGenerator _missionGenerator;
    private Timer _timer;
    private MissionReviewScreen _missionReviewScreen;
    private CriteriaList _criteriaList;
    private GameOverScreenUI _gameOverScreenUI;

    public override void OnEnter()
    {
        InitReferences();
        _playerAnimalInteractions.AnimalSelected += OnAnimalSelected;

        _timer.TimeUp += OnGameOver;

        GenerateNextMission();
        _criteriaList.UpdateCriteriaList(_currentMission);
        OnResume();
    }

    public override void OnExit()
    {
        _playerAnimalInteractions.AnimalSelected -= OnAnimalSelected;
        _timer.TimeUp -= OnGameOver;
    }


    public override void OnResume()
    {
        _playerInput.enabled = true;
        Time.timeScale = 1f;
        //Time.fixedDeltaTime = .02f * Time.timeScale; // This often fixes bugs with physics + timescale changees
    }

    public override void OnSuspend()
    {
        _playerInput.enabled = false;
        Time.timeScale = 0f;
        //Time.fixedDeltaTime = .02f * Time.timeScale; // This often fixes bugs with physics + timescale changees
    }

    private void InitReferences()
    {
        _playerInput = UnityEngine.Object.FindObjectOfType<PlayerInput>();
        _playerAnimalInteractions = UnityEngine.Object.FindObjectOfType<PlayerAnimalInteractions>();
        _missionGenerator = UnityEngine.Object.FindObjectOfType<MissionGenerator>();
        _timer = UnityEngine.Object.FindObjectOfType<Timer>();
        _missionReviewScreen = UnityEngine.Object.FindObjectOfType<MissionReviewScreen>();
        _criteriaList = UnityEngine.Object.FindObjectOfType<CriteriaList>();
        _gameOverScreenUI = UnityEngine.Object.FindObjectOfType<GameOverScreenUI>();
    }

    private void GenerateNextMission()
    {
        _missionGenerator.UpdateDifficulty(_animalsFound);
        _currentMission = _missionGenerator.Generate();
    }

    private void OnAnimalSelected(Animal animal)
    {
        // Get the result of the mission
        bool missionSuccess = _currentMission.IsSuccess(animal.AnimalType);
        Dictionary<AnimalCriterium, bool> missionResults = _currentMission.CriteriaSuccesses(animal.AnimalType);
        if (missionSuccess) _animalsFound++;
        Debug.Log($"Animal {animal.AnimalType} selected, mission success is {missionSuccess}");

        // Add or subtract from timer based on mission success
        if (missionSuccess) _timer.OnCorrectAnimalSelected();
        else _timer.OnWrongAnimalSelected();

        // TODO should we delay the following?
        GenerateNextMission();

        // TODO call mission result UI screen, use the missionSuccess & missionResults variables above
        _missionReviewScreen.SetUpMissionReview(missionResults, animal, missionSuccess, _currentMission);


        // TODO call mission start UI screen, use _currentMission.Criteria to get the criteria
        // TODO call mission spawning system to spawn the next animal
        GameObject.Destroy(animal.gameObject);
    }

    private void OnGameOver()
    {
        Debug.Log("GAME OVER -----------------------------------------");
        _gameOverScreenUI.ShowGameOverScreen(_timer.totalTime, _animalsFound);
        // TODO
    }
}
