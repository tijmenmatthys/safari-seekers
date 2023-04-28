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

    public override void OnEnter()
    {
        InitReferences();
        _playerAnimalInteractions.AnimalSelected += OnAnimalSelected;
        GenerateNextMission();
        OnResume();
    }

    public override void OnExit()
    {
        _playerAnimalInteractions.AnimalSelected -= OnAnimalSelected;
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
    }

    private void GenerateNextMission()
    {
        _missionGenerator.UpdateDifficulty(_animalsFound);
        _currentMission = _missionGenerator.Generate();
    }

    private void OnAnimalSelected(Animal animal)
    {
        bool missionSuccess = _currentMission.IsSuccess(animal.AnimalType);
        Dictionary<AnimalCriterium, bool> missionResults = _currentMission.CriteriaSuccesses(animal.AnimalType);
        if (missionSuccess) _animalsFound++;
        Debug.Log($"Animal {animal.AnimalType} selected, mission success is {missionSuccess}");

        // TODO call timing system to increase/decrease timer based on mission success
        // TODO call mission result UI screen, use the missionSuccess & missionResults variables above

        // TODO should we delay the following?
        GenerateNextMission();
        // TODO call mission start UI screen, use _currentMission.Criteria to get the criteria
        // TODO call mission spawning system to spawn the next animal
        GameObject.Destroy(animal.gameObject);
    }
}
