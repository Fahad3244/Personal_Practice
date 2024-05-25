using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorCheck : MonoBehaviour
{
    public Constructor[] constructor = new Constructor[3];

    private void Start()
    {
        constructor[1] = new Constructor("Fahad", 28);
    }
}
