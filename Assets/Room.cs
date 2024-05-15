using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public static Room instance;

    public int roomId;
    
    public event Action OnRoomEntered;
    public event Action OnRoomExit;

    private void Awake()
    {
        instance = this;
    }

    public void OnEnter()
    {
        if (OnRoomEntered != null)
        {
            Debug.Log("Entered");
            OnRoomEntered.Invoke();
        }
    }
    public void OnExit()
    {
        if (OnRoomExit != null)
        {
            Debug.Log("Exited");
            OnRoomExit.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnter();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnExit();
        }
    }
}
