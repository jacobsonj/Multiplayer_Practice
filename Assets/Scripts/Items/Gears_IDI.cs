using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gears_IDI : IDI_Base
{
    
    
    public Material materialActive;
    public Material materialInactive;
    // Start is called before the first frame update
    void Start()
    {
        name = "Gears_IDI";
    }

    // Update is called once per frame
    void Update()
    {
       

        if(active)
        {
            GetComponent<MeshRenderer> ().material = materialActive;
        }
        else if(!active)
        {
            GetComponent<MeshRenderer> ().material = materialInactive;
        }
    }

    public void toggleActive()
    {
        active = !active;
        sendState();
    }


}
