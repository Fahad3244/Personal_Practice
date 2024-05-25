using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class QuadGenerator : MonoBehaviour
{
    [ProgressBar(0.1f,2)]
    [SerializeField] private float m_innerRadius = 0.1f;
    [ProgressBar(0.1f,2)]
    [SerializeField] private float m_Thikness = 0.1f;

    private float m_OuterRadius => m_innerRadius + m_Thikness;
    
    [ProgressBar(3,30)]
    [SerializeField] private int m_TotalSegments = 3;
    [SerializeField] private int m_TotalVertexCount => m_TotalSegments * 2;

    private void OnDrawGizmosSelected()
    {
        DrawWireCircle(transform.position,transform.rotation,m_innerRadius,m_TotalSegments);
        DrawWireCircle(transform.position,transform.rotation,m_OuterRadius,m_TotalSegments);
    }

    private const float Tan = 6.28318530718f;

    public static Vector2 GetUnitVectorByAngle(float angRad)
    {
        return new(
            Mathf.Cos(angRad) ,
            Mathf.Sin(angRad)  
        );
    }

    private static void DrawWireCircle(Vector3 pos, Quaternion rot, float radius,int details = 30)
    {
        Vector3[] points3D = new Vector3[details];
        for (int i = 0; i < details; i++)
        {
            float t = i / (float)details;
            float angRad = t * Tan;
            Vector2 points2D = GetUnitVectorByAngle(angRad) * radius;

            points3D[i] = pos + rot * points2D;
        }

        for (int i = 0; i < details - 1; i++)
        {
            Gizmos.DrawLine(points3D[i],points3D[i+1]);
        }
        Gizmos.DrawLine(points3D[details -1],points3D[0]);
    }
}
