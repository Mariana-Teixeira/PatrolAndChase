using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState _currentState;

    public IState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public void Tick()
    {
        _currentState.Tick();
    }

    public void ChangeState(IState newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}