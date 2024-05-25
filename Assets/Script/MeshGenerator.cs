using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    [ProgressBar(0.1f,2)]
    [SerializeField] private float m_InnerRadius = 0.1f;
    [ProgressBar(0.1f,2)]
    [SerializeField] private float m_Thikness = 0.1f;

    private Mesh _mesh;

    private float m_OuterRadius => m_InnerRadius + m_Thikness;
    
    [ProgressBar(3,30)]
    [SerializeField] private int m_TotalSegmentCount = 3;
    [SerializeField] private int m_TotalVertexCount => m_TotalSegmentCount * 2;

    private void OnDrawGizmosSelected()
    {
        Gizmofs.DrawWireCircle(transform.position,transform.rotation,m_InnerRadius,m_TotalSegmentCount);
        Gizmofs.DrawWireCircle(transform.position,transform.rotation,m_OuterRadius,m_TotalSegmentCount);
    }

    private void Awake()
    {
        _mesh = new Mesh();
        _mesh.name = "New Mesh";
        GetComponent<MeshFilter>().sharedMesh = _mesh;
    }

    private void Update() => GenerateMesh();

    private void GenerateMesh()
    {
        _mesh.Clear();

        int vCount = m_TotalVertexCount;

        List<Vector3> verticies = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();

        for (int i = 0; i < m_TotalSegmentCount; i++)
        {
            float t = i / (float)m_TotalSegmentCount;
            float angRad = t * Mathfs.Tan;
            Vector2 dir = Mathfs.GetUnitVectorByAngle(angRad);
            
            Vector3 zOffset = Vector3. forward * Mathf. Cos ( angRad * 4 );
            
            verticies.Add((Vector3)(dir*m_OuterRadius));
            verticies.Add((Vector3)(dir*m_InnerRadius) + Vector3.forward);
            
            normals.Add(Vector3.forward);
            normals.Add(Vector3.forward);
            
            
        }

        List<int> triangleIndices = new List<int>();
        for (int i = 0; i < m_TotalSegmentCount; i++)
        {
            int indexRoot = i * 2;
            int indexInnerRoot = indexRoot + 1;
            int indexOuterNext = (indexRoot + 2) % vCount;
            int indexInnerNext = (indexRoot + 3) % vCount;
            
            triangleIndices.Add(indexRoot);
            triangleIndices.Add(indexOuterNext);
            triangleIndices.Add(indexInnerNext);
            
            triangleIndices.Add(indexRoot);
            triangleIndices.Add(indexInnerNext);
            triangleIndices.Add(indexInnerRoot);
        }
        
        _mesh.SetVertices(verticies);
        _mesh.SetTriangles(triangleIndices,0);
        _mesh.SetNormals(normals);
    }
}
