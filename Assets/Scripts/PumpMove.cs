﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMove : Player
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Pump";
        sendState();
        liftPos = new Vector3(0,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
