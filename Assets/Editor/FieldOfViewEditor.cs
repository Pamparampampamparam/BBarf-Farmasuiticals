using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]

public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 viewAngles01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngles02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngles01 * fov.radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngles02 * fov.radius);

        if (fov.laserPointerVisible)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.laserPointer.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
