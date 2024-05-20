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

    [SerializeField] private float m_OuterRadius => m_innerRadius + m_Thikness;
    
    [ProgressBar(3,250)]
    [SerializeField] private int m_TotalSegments = 3;

    private void OnDrawGizmosSelected()
    {
        DrawWireCircle(transform.position,transform.rotation,1);
    }

    private void Start()
    {
        DrawWireCircle(transform.position,transform.rotation,1);
    }

    const float Tan = 6.28318530718f;
    public static void DrawWireCircle(Vector3 pos, Quaternion rot, float radius,int details = 30)
    {
        Vector3[] points3D = new Vector3[details];
        for (int i = 0; i < details; i++)
        {
            float t = i / (float)details;
            float angRad = t * Tan;
            Vector2 points2D = new Vector2(
                Mathf.Cos(angRad) ,
                Mathf.Sin(angRad) 
            );

            points3D[i] = pos + rot * points2D;
        }

        for (int i = 0; i < details - 1; i++)
        {
            Gizmos.DrawLine(points3D[i],points3D[i+1]);
        }
        Gizmos.DrawLine(points3D[details -1],points3D[0]);
    }
}
