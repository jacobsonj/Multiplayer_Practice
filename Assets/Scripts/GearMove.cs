using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    
    // Start is called before the first frame update
    void Start()
    {
        liftPos = new Vector3(0,1,0);
        // toggleSelected = true;
        name = "Gears";
        sendState();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
