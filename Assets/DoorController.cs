using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour,IChangeColor
{
    public GameObject _door;
    public int doorId;
    void Start()
    {
        EventHandler.instance.OnDoorTriggerEnter += OpenDoor;
        EventHandler.instance.OnDoorTriggerExit += CloseDoor;
    }

    public void OpenDoor(int id)
    {
        if (id == this.doorId)
        {
            _door.transform.DOMoveY(3f, 0.3f).SetEase(Ease.OutBack);
        }
    }
    
    public void CloseDoor(int id)
    {
        if (id == this.doorId)
        {
            _door.transform.DOMoveY(1f, 0.5f).SetEase(Ease.Linear);   
        }
    }

    private void OnDisable()
    {
        EventHandler.instance.OnDoorTriggerEnter -= OpenDoor;
        EventHandler.instance.OnDoorTriggerExit -= CloseDoor;
    }

    private void OnTriggerEnter(Collider other)
    {
        EventHandler.instance.DoorTriggerEnter(doorId);
        ChangeColor(Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        EventHandler.instance.DoorTriggerExit(doorId);
        ChangeColor(Color.yellow);
    }

    public void ChangeColor(Color color)
    {
        _door.GetComponent<MeshRenderer>().material.color = color;
    }
}
