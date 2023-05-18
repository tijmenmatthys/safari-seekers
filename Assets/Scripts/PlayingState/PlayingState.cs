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
    private MusicManager _musicManager;
    private Dictionary<AnimalType, AnimalSpawner> _animalSpawners
        = new Dictionary<AnimalType, AnimalSpawner>();
    private TimePickup[] _timePickups;

    public override void OnEnter()
    {
        InitReferences();
        _musicManager?.PlayGameMusic();
        _playerAnimalInteractions.AnimalSelected += OnAnimalSelected;

        _timer.TimeUp += OnGameOver;

        GenerateNextMission();
        OnResume();
        _criteriaList.UpdateCriteriaList(_currentMission);
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
        _musicManager = UnityEngine.Object.FindObjectOfType<MusicManager>();
        _gameOverScreenUI = UnityEngine.Object.FindObjectOfType<GameOverScreenUI>();
        foreach (var spawner in UnityEngine.Object.FindObjectsOfType<AnimalSpawner>())
            _animalSpawners[spawner.AnimalType] = spawner;
        _timePickups = UnityEngine.Object.FindObjectsOfType<TimePickup>();
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

        // Next mission
        GenerateNextMission();

        // Launch mission review & next mission screens
        _missionReviewScreen.SetUpMissionReview(missionResults, animal, missionSuccess, _currentMission);

        // Respawn the selected animal
        _animalSpawners[animal.AnimalType].Respawn(animal);

        // Respawn pickups
        foreach (var pickup in _timePickups)
            pickup.Respawn();
    }

    private void OnGameOver()
    {
        Debug.Log("GAME OVER -----------------------------------------");
        _gameOverScreenUI.ShowGameOverScreen(_timer.totalTime, _animalsFound);
        // TODO
    }
}
