using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : IState
{
    PatrolController _patrolController;
    StateMachine _currentMachine;


    public Patrol(PatrolController patrolController, StateMachine currentMachine)
    {
        _patrolController = patrolController;
        _currentMachine = currentMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Patroling.");
    }

    public void Tick()
    {
        _patrolController.MoveThroughWaypoints();

        if (_patrolController.IsTargetInFOV)
            _currentMachine.ChangeState(_patrolController.Chase);
    }

    public void OnExit()
    {
    }
}
