using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayingState : State<States>
{
    private PlayerInput _playerInput;
    public override void OnEnter()
    {
        var playerMovement = UnityEngine.Object.FindObjectOfType<PlayerMovement>();
        _playerInput = playerMovement.GetComponent<PlayerInput>();
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
}
