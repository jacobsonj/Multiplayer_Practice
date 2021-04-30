using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Box_Base
{
    // Start is called before the first frame update
    void Start()
    {
        //assign name in editor
        print(name);
        BruteMove_Script = Brute.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        activeBox = BruteMove_Script.isLocalPlayer;
        if(activeBox == true)
        {
            sendBox();
        }
    }
}
