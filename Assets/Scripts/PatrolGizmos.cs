using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatrolGizmos : MonoBehaviour
{
    PatrolController controller;

    private void Awake()
    {
        controller = GetComponent<PatrolController>();
    }

    private void OnDrawGizmos()
    {
        if (controller == null) return;

        Gizmos.color = Conditions.IsTargetInFieldOfView
            (controller.transform, controller.Target, controller.RadiusFOV, controller.AngleFOV)
            ? Color.green : Color.red;

        for (float i = controller.AngleFOV; i > -controller.AngleFOV; i -= 15)
            Gizmos.DrawRay(transform.position, DirectionFromAngle(i / 2).normalized * controller.RadiusFOV);
    }

    Vector3 DirectionFromAngle(float viewAngle)
    {
        viewAngle += transform.eulerAngles.y;
        float viewAngleRad = viewAngle * Mathf.Deg2Rad;

        return new Vector3(
            Mathf.Sin(viewAngleRad),
            0,
            Mathf.Cos(viewAngleRad));
    }
}
