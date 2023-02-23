using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions
{
    public static bool IsTargetInFieldOfView(Transform selfTransform, Transform targetTransform, float viewRadius, float viewAngleDegrees)
    {
        viewAngleDegrees /= 2;

        if (Vector3.Distance(selfTransform.position, targetTransform.position) > viewRadius) return false;

        float viewAngleRad = (viewAngleDegrees) * Mathf.Deg2Rad;

        Vector3 localTargetPosition = (targetTransform.position - selfTransform.position).normalized;

        float dotProduct = Vector3.Dot(selfTransform.forward, localTargetPosition);
        dotProduct = Mathf.Clamp(dotProduct, -1f, 1f);
        float dotAngleRad = Mathf.Acos(dotProduct);

        return dotAngleRad < viewAngleRad ? true : false;
    }
}
