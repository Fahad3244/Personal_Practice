using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDitector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawRaycast();
        }
    }

    void DrawRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 500;

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,distance))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponentInParent<BoxOnCollision>().OnDestroy();
        }
        
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 2.0f);
    }
}
