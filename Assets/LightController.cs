using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour ,IChangeColor
{
    public Light _light;
    public int lightId;
    void Start()
    {
        lightId = GetComponentInParent<DoorController>().doorId;
        _light.color = Color.red;   
        
        EventHandler.instance.OnDoorTriggerEnter += SwitchOn;
        EventHandler.instance.OnDoorTriggerExit += SwitchOff;
    }

    public void SwitchOn(int id)
    {
        if (id == lightId)
        {
            ChangeColor(Color.green);
        }
    }
    
    public void SwitchOff(int id)
    {
        if (id == lightId)
        {
            ChangeColor(Color.red);
        }
    }

    private void OnDisable()
    {
        EventHandler.instance.OnDoorTriggerEnter -= SwitchOn;
        EventHandler.instance.OnDoorTriggerExit -= SwitchOff;
    }

    public void ChangeColor(Color color)
    {
        _light.color = color;   
    }
}
