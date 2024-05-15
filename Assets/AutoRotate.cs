using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the GameObject based on the rotation speed along each axis
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
