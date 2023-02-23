using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : IState
{
    PatrolController _patrolController;
    StateMachine _currentMachine;

    public Chase(PatrolController enemyManager, StateMachine currentMachine)
    {
        _patrolController = enemyManager;
        _currentMachine = currentMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Chasing.");
    }

    public void Tick()
    {
        _patrolController.MoveTowardsTarget();

        if (!_patrolController.IsTargetInFOV)
            _currentMachine.ChangeState(_patrolController.Patrol);
    }

    public void OnExit()
    {
    }
}
