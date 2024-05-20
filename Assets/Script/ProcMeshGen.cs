using System.Collections.Generic;
using UnityEngine;

public class ProcMeshGen : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new()
        {
            name = "ProcMesh"
        };

        List<Vector3> points = new()
        {
            new Vector3(1,1),
            new Vector3(-1,1),
            new Vector3(1,-1),
            new Vector3(-1, -1)
        };

        int[] triangles = { 1, 2, 0, 1, 3, 2 };
        
        mesh.SetVertices(points);
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }
}
