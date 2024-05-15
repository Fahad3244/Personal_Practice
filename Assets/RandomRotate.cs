using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private Vector3 rotationSpeed;

    void Update()
    {
        rotationSpeed = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        // Rotate the GameObject based on the rotation speed along each axis
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
