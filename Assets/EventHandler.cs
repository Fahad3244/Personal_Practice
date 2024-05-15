using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler instance;

    public delegate void TestDeligate();

    private TestDeligate _testDeligateFunction;
    
    public event Action<int> OnDoorTriggerEnter;
    public event Action<int> OnDoorTriggerExit;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _testDeligateFunction += DeligateFunctionOne;
        _testDeligateFunction += DeligateFunctionTwo;
        
        _testDeligateFunction();
    }

    public void DeligateFunctionOne()
    {
        Debug.Log("Function one called");
    }
    
    public void DeligateFunctionTwo()
    {
        Debug.Log("Function Two called");
    }

    public void DoorTriggerEnter(int doorId)
    {
        if (OnDoorTriggerEnter != null)
        {
            OnDoorTriggerEnter.Invoke(doorId);
        }
    }
    
    public void DoorTriggerExit(int doorId)
    {
        if (OnDoorTriggerExit != null)
        {
            OnDoorTriggerExit.Invoke(doorId);
        }
    }
}
