using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;

public class PatrolController : MonoBehaviour
{
    Patrol _patrol;
    Chase _chase;

    StateMachine _stateMachine;
    public Transform _target;

    float radiusFOV = 8.0f;
    float angleFOV = 90f;

    NavMeshAgent _agent;
    public Transform[] _waypoints;
    int waypointIndex;

    public Transform Target
    { get { return _target; } }

    public Patrol Patrol
    { get { return _patrol; } }

    public Chase Chase
    { get { return _chase; } }

    public float RadiusFOV
    {
        get { return radiusFOV; }
    }

    public float AngleFOV
    {
        get
        {
            return angleFOV;
        }
    }

    public bool IsTargetInFOV
    {
        get
        {
            return Conditions.IsTargetInFieldOfView(this.transform, Target, radiusFOV, angleFOV);
        }
    }

    void Start()
    {
        _stateMachine = new StateMachine();

        _patrol = new Patrol(this, _stateMachine);
        _chase = new Chase(this, _stateMachine);

        _stateMachine.CurrentState = Patrol;
        _stateMachine.CurrentState.OnEnter();

        _agent = GetComponent<NavMeshAgent>();
    }

    void Update() =>  _stateMachine.Tick();

    public void MoveThroughWaypoints()
    {
        if (_agent.remainingDistance > 0.01f) return;
        if (waypointIndex >= _waypoints.Length) waypointIndex = 0;

        _agent.SetDestination(_waypoints[waypointIndex].position);
        waypointIndex++;
    }

    public void MoveTowardsTarget()
    {
        if (Target == null) return;

        _agent.SetDestination(Target.position);
    }
}