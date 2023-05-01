using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private StateMachine<States> _stateMachine;

    void Start()
    {
        _stateMachine = new StateMachine<States>();
        _stateMachine.Register(States.Menu, new MenuState());
        _stateMachine.Register(States.Playing, new PlayingState());
        _stateMachine.Register(States.Paused, new PausedState());
        _stateMachine.Transition(States.Playing);
    }

    void Update()
    {
        // if needed later, update the current state here
    }

    public void TransitionToPause()
    {
        _stateMachine.Transition(States.Paused);
    }

    public void TransitionToPlaying()
    {
        _stateMachine.Transition(States.Playing, true);
    }
}
