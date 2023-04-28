using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayingState : State<States>
{
    private int _animalsFound = 10;
    private Mission currentMission;

    private PlayerInput _playerInput;
    private MissionGenerator _missionGenerator;

    public override void OnEnter()
    {
        InitReferences();
        GenerateNextMission();
        OnResume();
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
        var playerMovement = UnityEngine.Object.FindObjectOfType<PlayerMovement>();
        _playerInput = playerMovement.GetComponent<PlayerInput>();
        _missionGenerator = UnityEngine.Object.FindObjectOfType<MissionGenerator>();
    }

    public void GenerateNextMission()
    {
        _missionGenerator.UpdateDifficulty(_animalsFound);
        currentMission = _missionGenerator.Generate();
    }
}
