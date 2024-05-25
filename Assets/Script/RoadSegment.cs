using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class RoadSegment : MonoBehaviour
{
    [SerializeField] private Transform[] controlPoints;

    public Vector3 GetPos(int i) => controlPoints[i].position;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < controlPoints.Length; i++)
        {
            Gizmos.DrawSphere(GetPos(i),0.05f);
        }
        
        Handles.DrawBezier(
            controlPoints[0].position,
            controlPoints[^1].position,
            controlPoints[1].position,
            controlPoints[2].position,
            Color.white, 
            EditorGUIUtility.whiteTexture,
            1f
            );
    }
}
