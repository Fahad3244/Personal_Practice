using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Gizmofs : MonoBehaviour
{
    public static void DrawWireCircle(Vector3 pos, Quaternion rot, float radius,int details = 30)
    {
        Vector3[] points3D = new Vector3[details];
        for (int i = 0; i < details; i++)
        {
            float t = i / (float)details;
            float angRad = t * Mathfs.Tan;
            Vector2 points2D = Mathfs.GetUnitVectorByAngle(angRad) * radius;

            points3D[i] = pos + rot * points2D;
        }

        for (int i = 0; i < details - 1; i++)
        {
            Gizmos.DrawLine(points3D[i],points3D[i+1]);
        }
        Gizmos.DrawLine(points3D[details -1],points3D[0]);
    }
}
