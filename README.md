# PatrolAndChase

This Unity Project demonstrates the use of a Finite State Machine model for developing a simple Patrol and Chase AI that can be expanded to other behaviors.
It was developed during 2022, currently using Unity's version 2021.3.16f1, to study and cement my understanding of the Finite State Machine model.

The functionality of the Finite State Machine depends on a PatrolController component. Every state class (e.g "Patrol", "Chase") must have access to properties and functions of the PatrolController component (e.g "MoveThroughWaypoint()", "IsTargetInFOV"), including other state objects they can transition to.

The static class Conditions has functions that return a boolean for conditions required for state objects to transition between each other. This class is decoupled from the PatrolController and Finite State Machine, allowing it to be used outside of a Patrol and Chase behavior.

For future iterations, a similar approach should be use for the State objects, decoupling them from the PatrolController and refacturing them to become more modular. This would allow them to be used in behaviors that don't require a Patrol and Chase AI.
