using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUbeSpawner : MonoBehaviour
{
    public Transform cubeSpawnPoint;
    [SerializeField] private Object cubePrefab;
    [SerializeField] private float spawnSpeed;

    void Start()
    {
        InvokeRepeating("SpawnCube",1,spawnSpeed);
    }

    public void SpawnCube()
    {
        Vector3 newPos = new Vector3(Random.Range(cubeSpawnPoint.position.x + 6,cubeSpawnPoint.position.x - 6),cubeSpawnPoint.position.y,cubeSpawnPoint.position.z);
        Instantiate(cubePrefab, newPos, Quaternion.identity);
    }
}
